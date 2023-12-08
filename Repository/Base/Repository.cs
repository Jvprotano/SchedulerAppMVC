using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
private readonly DbSet<T> _dbSet;
private ApplicationDbContext _context;
public Repository(ApplicationDbContext context)
{
    _context = context;
    _dbSet = _context.Set<T>();
}

public DbSet<T> DbSet { get => _dbSet; }

public virtual async Task SaveAsync(T entity)
{
    try
    {
await this.DbSet.AddAsync(entity);
await this._context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
throw new Exception(ex.Message);
    }
}
    }
}