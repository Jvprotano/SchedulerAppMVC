using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
***REMOVED***private readonly DbSet<T> _dbSet;
***REMOVED***private ApplicationDbContext _context;
***REMOVED***public Repository(ApplicationDbContext context)
***REMOVED***{
***REMOVED***    _context = context;
***REMOVED***    _dbSet = _context.Set<T>();
***REMOVED***}

***REMOVED***public DbSet<T> DbSet { get => _dbSet; }

***REMOVED***public virtual async Task SaveAsync(T entity)
***REMOVED***{
***REMOVED***    try
***REMOVED***    {
***REMOVED******REMOVED***await this.DbSet.AddAsync(entity);
***REMOVED******REMOVED***await this._context.SaveChangesAsync();
***REMOVED***    }
***REMOVED***    catch (Exception ex)
***REMOVED***    {
***REMOVED******REMOVED***throw new Exception(ex.Message);
***REMOVED***    }
***REMOVED***}
    }
}