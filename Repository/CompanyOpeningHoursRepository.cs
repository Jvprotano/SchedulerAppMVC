using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAgendamentos.Enums;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using AppAgendamentos.Contracts.Repository;
using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Repository
{
    public class CompanyOpeningHoursRepository : ICompanyOpeningHoursRepository
    {
***REMOVED***private readonly ApplicationDbContext _context;

***REMOVED***public CompanyOpeningHoursRepository(ApplicationDbContext context)
***REMOVED***{
***REMOVED***    _context = context;
***REMOVED***}

***REMOVED***public List<CompanyOpeningHours> GetAll(int companyId)
***REMOVED***{
***REMOVED***    return this._context.CompanyOpeningHours.Where(c => c.CompanyId == companyId).ToList();
***REMOVED***}
***REMOVED***public List<CompanyOpeningHours> GetByDayOfWeek(int companyId, DayOfWeek dayOfWeek)
***REMOVED***{
***REMOVED***    return this._context.CompanyOpeningHours
***REMOVED******REMOVED***    .Include(c => c.Company).ThenInclude(c=> c.ServicesOffered)
***REMOVED******REMOVED***    .Where(c => c.CompanyId == companyId && c.DayOfWeek == dayOfWeek)
***REMOVED******REMOVED***    .ToList();
***REMOVED***}
    }
}