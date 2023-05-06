using CultureSpot.Application.DTO;

namespace CultureSpot.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}