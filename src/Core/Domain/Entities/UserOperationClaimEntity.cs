using Domain.Common;
using Domain.Entities;

namespace Domain.Entities;

public class UserOperationClaimEntity : BaseEntity
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual UserEntity User { get; set; } = null!;
    public virtual OperationClaimEntity OperationClaim { get; set; } = null!;

    public UserOperationClaimEntity(int userId, int operationClaimId)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
    
    public UserOperationClaimEntity(int id, int userId, int operationClaimId)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}