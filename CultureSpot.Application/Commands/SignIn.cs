using CultureSpot.Application.Shared;

namespace CultureSpot.Application.Commands;

public record SignIn(string Email, string Password) : CommandBase;