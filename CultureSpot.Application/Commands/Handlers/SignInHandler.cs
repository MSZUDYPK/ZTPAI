using CultureSpot.Application.Security;
using CultureSpot.Core.Users.Repositories;
using CultureSpot.Application.Exceptions;
using CultureSpot.Application.Shared;

namespace CultureSpot.Application.Commands.Handlers;

internal sealed class SignInHandler : ICommandHandler<SignIn>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenStorage _tokenStorage;

    public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator,
        IPasswordManager passwordManager, ITokenStorage tokenStorage) 
        => (_userRepository, _authenticator, _passwordManager, _tokenStorage) 
        = (userRepository, authenticator, passwordManager, tokenStorage);

    public async Task Handle(SignIn request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email) ?? throw new InvalidCredentialsException();

        if (!_passwordManager.Validate(request.Password, user.Password))
        {
            throw new InvalidCredentialsException();
        }

        var jwt = _authenticator.CreateToken(user.Id, user.Role);
        _tokenStorage.Set(jwt);
    }
}