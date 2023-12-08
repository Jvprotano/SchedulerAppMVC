using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models.Base;

using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Repository.Base;
public class Repository<T> : IRepository<T> where T : BaseEntity
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
            var query = this.DbSet.AsNoTracking();

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
            var query = this.DbSet.AsNoTracking();

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
                await this.DbSet.AddAsync(entity);
            }
            else
            {
                this._context.Entry(entity).State = EntityState.Modified;
            }
            await this._context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}