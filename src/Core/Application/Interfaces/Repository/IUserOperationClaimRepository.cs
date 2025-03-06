using Domain.Entities;

namespace Application.Interfaces.Repository;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaimEntity>, IRepository<UserOperationClaimEntity>
{
}