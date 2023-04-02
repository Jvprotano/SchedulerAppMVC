using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Enums;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using AppAgendamentos.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AppAgendamentos.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
***REMOVED***public CompanyRepository(ApplicationDbContext context) : base(context)
***REMOVED***{
***REMOVED***}
***REMOVED***public override Task SaveAsync(Company entity)
***REMOVED***{
***REMOVED***    try
***REMOVED***    {
***REMOVED******REMOVED***return base.SaveAsync(entity);
***REMOVED***    }
***REMOVED***    catch (Exception ex)
***REMOVED***    {
***REMOVED******REMOVED***throw new Exception(ex.Message);
***REMOVED***    }
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