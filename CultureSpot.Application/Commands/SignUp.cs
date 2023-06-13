using CultureSpot.Application.Shared;

namespace CultureSpot.Application.Commands;

public record SignUp(string Email, string Password) : CommandBase<Guid>;
