using MediatR;

namespace CultureSpot.Application.Commands;

public record SignIn(string Email, string Password) : IRequest;