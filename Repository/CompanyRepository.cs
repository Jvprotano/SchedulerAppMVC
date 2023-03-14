using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;

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
    }
}