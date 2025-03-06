using Application.Interfaces.Repository;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class UserOperationClaimRepository : BaseRepository<UserOperationClaimEntity, DataContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(DataContext context) : base(context)
    {
    }
}