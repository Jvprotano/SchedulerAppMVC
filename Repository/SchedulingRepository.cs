using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using AppAgendamentos.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Repository;
public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
{
    public SchedulingRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Scheduling>> GetAllByDateAsync(int companyId, DateOnly date)
    {
        return await DbSet.Where(c => c.CompanyId == companyId &&
            c.ScheduledDate.Date == date.ToDateTime(TimeOnly.Parse("10:00 PM")).Date)
            .ToListAsync();
    }
}