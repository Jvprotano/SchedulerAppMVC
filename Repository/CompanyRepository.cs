using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Enums;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AppAgendamentos.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
***REMOVED***private readonly ApplicationDbContext _context;

***REMOVED***public CompanyRepository(ApplicationDbContext context)
***REMOVED***{
***REMOVED***    _context = context;
***REMOVED***}
***REMOVED***public async Task Save(Company company)
***REMOVED***{
***REMOVED***    try
***REMOVED***    {
***REMOVED******REMOVED***await _context.Companies.AddAsync(company);

***REMOVED******REMOVED***await _context.SaveChangesAsync();
***REMOVED***    }
***REMOVED***    catch (Exception ex)
***REMOVED***    {
***REMOVED******REMOVED***throw new Exception(ex.Message);
***REMOVED***    }

***REMOVED***}

***REMOVED***public async Task<Company> GetAsync(int id)
***REMOVED***{
***REMOVED***    return await this._context.Companies
***REMOVED******REMOVED***.Include(c => c.ServicesOffered)
***REMOVED******REMOVED***.Where(c => c.Id == id).FirstOrDefaultAsync();
***REMOVED***}

***REMOVED***public async Task<IEnumerable<Company>> GetAllAsync()
***REMOVED***{
***REMOVED***    return await this._context.Companies.Where(c => c.Status == StatusEnum.Active).ToListAsync();
***REMOVED***}
    }
}