using MediatR;
using CultureSpot.Application.Security;
using CultureSpot.Application.Exceptions;
using CultureSpot.Core.Users.Entities;
using CultureSpot.Core.Users.Repositories;
using CultureSpot.Core.Users.ValueObjects;

namespace CultureSpot.Application.Commands.Handlers;

internal sealed class SignUpHandler : IRequestHandler<SignUp>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;

    public SignUpHandler(IUserRepository userRepository, IPasswordManager passwordManager)
        => (_userRepository, _passwordManager) = (userRepository, passwordManager);

    public async Task Handle(SignUp command, CancellationToken cancellationToken)
    {
        var userId = new UserId(command.UserId);
        var email = new Email(command.Email);
        var username = new Username(command.Username);
        var password = new Password(command.Password);
        var firstName = new FirstName(command.FirstName);
        var lastName = new LastName(command.LastName);
        var phoneNumber = new PhoneNumber(command.PhoneNumber);
        var role = new Role("user");

        if (await _userRepository.GetByEmailAsync(email) is not null)
        {
            throw new EmailAlreadyInUseException(email);
        }

        if (await _userRepository.GetByUsernameAsync(username) is not null)
        {
            throw new UsernameAlreadyInUseException(username);
        }

        var securedPassword = _passwordManager.Secure(password);
        var user = new User(userId, username, email, securedPassword, firstName, lastName, phoneNumber, role);
        await _userRepository.AddAsync(user);
    }
}
