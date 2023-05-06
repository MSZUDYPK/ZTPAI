using MediatR;

namespace CultureSpot.Application.Commands;

public record SignUp(Guid UserId, string Email, string Username, string Password, string FirstName, string LastName, string PhoneNumber) : IRequest;
