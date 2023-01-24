using GMS.Identity.Core.Abstractions.Repositories;
using GMS.Identity.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.DataAccess.Repositories;

public class GenericRepository<T> : IRepository<T> 
    where T : BaseEntity
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> Get()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public IEnumerable<T> Get(Func<T, bool> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate).ToList();
    }
    public T FindById(Guid id)
    {
        return _dbSet.Find(id);
    }

    public async Task<bool> CreateAsync(T item)
    {
        _dbSet.Add(item);
        _context.SaveChanges();
        return true;
    }
    public async Task<bool> UpdateAsync(T item)
    {
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
        return true;
    }
    public async Task<bool> RemoveAsync(T item)
    {
        _dbSet.Remove(item);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

    public IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.Where(predicate).ToList();
    }

    private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}
