using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Enums;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using AppAgendamentos.Repository.Base;

using Microsoft.EntityFrameworkCore;

using System.Data;

namespace AppAgendamentos.Repository;
public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext context) : base(context)
    {
    }
    public override async Task<Company> GetByIdAsync(int id, bool active = true)
    {
        var query = this.DbSet
            .Include(c => c.ServicesOffered)
            .Where(c => c.Id == id);

        return await query.FirstOrDefaultAsync();
    }
    public override async Task<IEnumerable<Company>> GetAllAsync(bool active = true)
    {
        return await this.DbSet.Where(c => c.Status == StatusEnum.Active).ToListAsync();
    }
}