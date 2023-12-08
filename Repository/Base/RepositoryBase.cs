using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
***REMOVED***private readonly DbSet<T> _dbSet;
***REMOVED***private ApplicationDbContext _context;
***REMOVED***public RepositoryBase(ApplicationDbContext context)
***REMOVED***{
***REMOVED***    _context = context;
***REMOVED***    _dbSet = _context.Set<T>();
***REMOVED***}

***REMOVED***public DbSet<T> DbSet { get => _dbSet; }

***REMOVED***public virtual async Task SaveAsync(T entity)
***REMOVED***{
***REMOVED***    await this.DbSet.AddAsync(entity);
***REMOVED***    await this._context.SaveChangesAsync();
***REMOVED***}
    }
}