using DrivenDomain.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DrivenDomain.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> where TEntity : class
{
    private readonly DrivenDomainContext _context;

    protected RepositoryBase(DrivenDomainContext context)
    {
        _context = context;
    }

    protected virtual async Task<TEntity> Add(TEntity entity)
    {
        var result = await _context.Set<TEntity>().AddAsync(entity);
        return result.Entity;
    }

    protected virtual async Task<IEnumerable<TEntity>> FindAllAsync(int page, int pageSize)
    {
        var result = await _context
            .Set<TEntity>()
            .Skip(page - 1 * (pageSize))
            .Take(pageSize)
            .ToListAsync();
            
        return result;
    }
}