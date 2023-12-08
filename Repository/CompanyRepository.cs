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
***REMOVED***public CompanyRepository(ApplicationDbContext context) : base(context)
***REMOVED***{
***REMOVED***}
***REMOVED***public async Task<Company> GetAsync(int id)
***REMOVED***{
***REMOVED***    return await this.DbSet
***REMOVED******REMOVED***.Include(c => c.ServicesOffered)
***REMOVED******REMOVED***.Where(c => c.Id == id).FirstOrDefaultAsync();
***REMOVED***}

***REMOVED***public async Task<IEnumerable<Company>> GetAllAsync()
***REMOVED***{
***REMOVED***    return await this.DbSet.Where(c => c.Status == StatusEnum.Active).ToListAsync();
***REMOVED***}
    }
}