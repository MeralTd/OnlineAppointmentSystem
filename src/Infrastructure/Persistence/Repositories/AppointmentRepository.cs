using Application.Interfaces.Repository;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class AppointmentRepository : GenericRepository<AppointmentEntity, DataContext>, IAppointmentRepository
{
}