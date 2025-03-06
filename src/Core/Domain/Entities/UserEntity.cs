using Domain.Common;
using Domain.Enums.UserEnums;

namespace Domain.Entities;

public class UserEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public UserTypeEnum Type { get; set; }
    public GenderEnum Gender { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<UserOperationClaimEntity> UserOperationClaims { get; set; }
    public ICollection<AppointmentEntity> Appointments { get; set; }
}