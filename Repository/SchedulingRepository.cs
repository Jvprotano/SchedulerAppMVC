using Microsoft.EntityFrameworkCore;

using Scheduler.Contracts.Repositories;
using Scheduler.Infrastructure;
using Scheduler.Models;
using Scheduler.Repository.Base;

namespace Scheduler.Repository;
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

    public async Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(int companyId, DateTime initialDate, DateTime finalDate)
    {
        return await this.DbSet
        .Include(c => c.ServiceOffered)
        .Include(c => c.Customer)
        .Where(c => c.CompanyId == companyId && c.ScheduledDate.Date >= initialDate.Date && c.ScheduledDate.Date <= finalDate.Date)
        .OrderBy(c => c.ScheduledDate)
        .ToListAsync();
    }
}