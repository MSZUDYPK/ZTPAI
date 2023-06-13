using CultureSpot.Application.Security;
using CultureSpot.Application.Exceptions;
using CultureSpot.Core.Users.Entities;
using CultureSpot.Core.Users.Repositories;
using CultureSpot.Core.Users.ValueObjects;
using CultureSpot.Application.Shared;

namespace CultureSpot.Application.Commands.Handlers;

internal sealed class SignUpHandler : ICommandHandler<SignUp, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;

    public SignUpHandler(IUserRepository userRepository, IPasswordManager passwordManager)
        => (_userRepository, _passwordManager) = (userRepository, passwordManager);

    public async Task<Guid> Handle(SignUp command, CancellationToken cancellationToken)
    {
        var userId = new UserId(Guid.NewGuid());
        var email = new Email(command.Email);
        var password = new Password(command.Password);
        var role = new Role("user");
        var createdAt = DateTime.UtcNow;

        if (await _userRepository.GetByEmailAsync(email) is not null)
        {
            throw new EmailAlreadyInUseException(email);
        }

        var securedPassword = _passwordManager.Secure(password);
        var user = new User(userId, email, securedPassword, null, null, null, role, createdAt);
        await _userRepository.AddAsync(user);

        return userId;
    }
}
