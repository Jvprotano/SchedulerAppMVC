using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using AppAgendamentos.Repository.Base;

namespace AppAgendamentos.Repository
{
    public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
    {
public SchedulingRepository(ApplicationDbContext context) : base(context)
{
}

public List<Scheduling> GetAllByDate(int companyId, DateOnly date)
{
    return this.DbSet
.Where(c => c.CompanyId == companyId &&
c.ScheduledDate.Date == date.ToDateTime(TimeOnly.Parse("10:00 PM")).Date)
.ToList();
}
    }
}