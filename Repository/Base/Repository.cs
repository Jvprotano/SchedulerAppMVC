using Scheduler.Contracts.Repositories.Base;
using Scheduler.Infrastructure;
using Scheduler.Models.Base;

using Microsoft.EntityFrameworkCore;

namespace Scheduler.Repository.Base;
public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly DbSet<T> _dbSet;
    private ApplicationDbContext _context;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public DbSet<T> DbSet { get => _dbSet; }
    public virtual async Task<IEnumerable<T>> GetAllAsync(bool active = true)
    {
        try
        {
            var query = DbSet.AsNoTracking();

            if (!active)
                query = query.IgnoreQueryFilters();

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public virtual async Task<T> GetByIdAsync(int id, bool active = true)
    {
        try
        {
            var query = DbSet.AsNoTracking();

            if (!active)
                query = query.IgnoreQueryFilters();

            return await query.FirstOrDefaultAsync(e => (int)e.GetType().GetProperty("Id").GetValue(e) == id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public virtual async Task SaveAsync(T entity)
    {
        try
        {
            if (entity.Id == 0)
            {
                await DbSet.AddAsync(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
                BeforeUpdateChanges(entity);
            }
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual async Task TemporaryDeleteAsync(T entity)
    {
        try
        {
            entity.Status = Enums.StatusEnum.TemporaryRemoved;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual async Task DeleteAsync(T entity)
    {
        try
        {
            entity.Status = Enums.StatusEnum.Removed;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<T> GetAsync(int id, bool active = true)
    {
        var query = DbSet.AsNoTracking()
            .Where(e => e.Id == id);

        if (!active)
            query = query.IgnoreQueryFilters();

        return await query.FirstOrDefaultAsync();
    }
    public virtual void UpdateCollection<U>(IEnumerable<U> collection)
    {
        if (collection == null)
            return;
        foreach (var entity in collection)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
    public virtual void BeforeUpdateChanges(T entity)
    {
    }

}