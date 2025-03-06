using Application.Interfaces.Repository;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<UserEntity, DataContext>, IUserRepository
{
}