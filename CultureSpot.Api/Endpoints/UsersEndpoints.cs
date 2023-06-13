using CultureSpot.Application.Commands;
using CultureSpot.Application.DTO;
using CultureSpot.Application.Queries;
using CultureSpot.Application.Security;
using CultureSpot.Core.Users.ValueObjects;
using MediatR;


namespace CultureSpot.Api.Endpoints;

internal static class UsersEndpoints
{
    private const string MeRoute = "me";

    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        var usersEndpoints = app.MapGroup("api/users");

        usersEndpoints.MapGet(MeRoute, (IMediator mediator, IHttpContextAccessor httpContextAccessor) => GetMe(mediator, httpContextAccessor))
                      .Produces<UserDto>(StatusCodes.Status200OK)
                      .Produces(StatusCodes.Status404NotFound)
                      .WithName(MeRoute)
                      .WithTags("User Getters")
                      .RequireAuthorization();

        usersEndpoints.MapGet("{userId:Guid}", (Guid userId, IMediator mediator) => GetById(userId, mediator))
                      .Produces<UserDto>(StatusCodes.Status200OK)
                      .Produces(StatusCodes.Status404NotFound)
                      .Produces(StatusCodes.Status403Forbidden)
                      .Produces(StatusCodes.Status401Unauthorized)
                      .WithName("GetUserById")
                      .WithTags("User Getters")
                      .RequireAuthorization();

        usersEndpoints.MapPost("sign-in", (SignIn command, IMediator mediator, ITokenStorage tokenStorage) => SignIn(command, mediator, tokenStorage))
                      .Produces<JwtDto>(StatusCodes.Status200OK)
                      .Produces(StatusCodes.Status404NotFound)
                      .Produces(StatusCodes.Status400BadRequest)
                      .WithName("SignIn")
                      .WithTags("User Auth");

        usersEndpoints.MapPost("sign-up", (SignUp command, IMediator mediator) => SignUp(command, mediator))
                      .Produces(StatusCodes.Status201Created)
                      .Produces(StatusCodes.Status400BadRequest)
                      .WithName("SignUp")
                      .WithTags("User Auth");

        return usersEndpoints;
    }

    private static async Task<IResult> GetMe(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        if (string.IsNullOrWhiteSpace(httpContextAccessor.HttpContext.User.Identity?.Name))
        {
            return Results.NotFound();
        }

        var userId = Guid.Parse(httpContextAccessor.HttpContext.User.Identity.Name);
        var user = await mediator.Send(new GetUser() { UserId = userId });

        return user is not null ? Results.Ok(user) : Results.NotFound();
    }

    private static async Task<IResult> GetById(Guid userId, IMediator mediator)
    {
        var user = await mediator.Send(new GetUser { UserId = userId });
        return user is not null ? Results.Ok(user) : Results.NotFound();
    }

    private static async Task<IResult> SignIn(SignIn command, IMediator mediator, ITokenStorage tokenStorage)
    {
        await mediator.Send(command);
        var jwt = tokenStorage.Get();
        return Results.Ok(jwt);
    }

    private static async Task<IResult> SignUp(SignUp command, IMediator mediator)
    {
        var userId = await mediator.Send(command);
        return Results.Created("api/users/{userId:Guid}", userId);
    }
}