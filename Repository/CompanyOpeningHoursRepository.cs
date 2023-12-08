using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using AppAgendamentos.Repository.Base;

using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Repository
{
    public class CompanyOpeningHoursRepository : Repository<CompanyOpeningHours>, ICompanyOpeningHoursRepository
    {
public CompanyOpeningHoursRepository(ApplicationDbContext context) 
: base(context)
{
}

public List<CompanyOpeningHours> GetAll(int companyId)
{
    return this.DbSet.Where(c => c.CompanyId == companyId).ToList();
}
public List<CompanyOpeningHours> GetByDayOfWeek(int companyId, DayOfWeek dayOfWeek)
{
    return this.DbSet
    .Include(c => c.Company).ThenInclude(c=> c.ServicesOffered)
    .Where(c => c.CompanyId == companyId && c.DayOfWeek == dayOfWeek)
    .ToList();
}
    }
}