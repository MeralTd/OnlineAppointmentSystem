using Domain.Common;

namespace Domain.Entities;

public class OperationClaimEntity : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<UserOperationClaimEntity> UserOperationClaims { get; set; } = null!;

    public OperationClaimEntity()
    {
        Name = string.Empty;
    }

    public OperationClaimEntity(string name)
    {
        Name = name;
    }

    public OperationClaimEntity(int id, string name)
    {
        Name = name;
    }
}