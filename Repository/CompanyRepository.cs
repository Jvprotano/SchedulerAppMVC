using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Enums;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using AppAgendamentos.Repository.Base;

using Microsoft.EntityFrameworkCore;

using System.Data;

namespace AppAgendamentos.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
public CompanyRepository(ApplicationDbContext context) : base(context)
{
}
public async Task<Company> GetAsync(int id)
{
    return await this.DbSet
.Include(c => c.ServicesOffered)
.Where(c => c.Id == id).FirstOrDefaultAsync();
}

public async Task<IEnumerable<Company>> GetAllAsync()
{
    return await this.DbSet.Where(c => c.Status == StatusEnum.Active).ToListAsync();
}
    }
}