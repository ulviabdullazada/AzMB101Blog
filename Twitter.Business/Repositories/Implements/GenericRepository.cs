using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Core.Entities.Common;
using Twitter.DAL.Contexts;

namespace Twitter.Business.Repositories.Implements;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    TwitterContext _context { get; }

    public GenericRepository(TwitterContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool noTracking = true, params string[] includes)
    {
        var query = _applyIncludes(Table.AsQueryable(), includes);
        return noTracking ? query.AsNoTracking() : query;
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
    {
        return await Table.AnyAsync(expression);
    }

    public async Task CreateAsync(T data)
    {
        await Table.AddAsync(data);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] includes)
    {
        var query = _applyIncludes(Table.AsQueryable(), includes);
        return noTracking ? await query.AsNoTracking().SingleOrDefaultAsync(t=> t.Id == id) : await query.SingleOrDefaultAsync(t => t.Id == id);
    }

    public void Remove(T data)
    {
        Table.Remove(data);
    }
    IQueryable<T> _applyIncludes(IQueryable<T> query, params string[] includes)
    {
        if (includes != null && includes.Length > 0)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool noTracking = true, params string[] includes)
    {
        var query = _applyIncludes(Table.AsQueryable(), includes);
        return noTracking ? await query.AsNoTracking().SingleOrDefaultAsync(expression) : await query.SingleOrDefaultAsync(expression);
    }
}
