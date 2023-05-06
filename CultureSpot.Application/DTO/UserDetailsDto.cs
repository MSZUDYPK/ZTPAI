using CultureSpot.Application.DTO;

namespace CultureSpot.Application.DTO;

public class UserDetailsDto : UserDto
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
}