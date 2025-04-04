using Domain.Enums.UserEnums;

namespace Application.Features.Users.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; } = true;
    public UserTypeEnum Type { get; set; }
    public GenderEnum Gender { get; set; }

}