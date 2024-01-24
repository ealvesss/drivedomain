using DrivenDomain.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DrivenDomain.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> where TEntity : class
{
    private readonly DrivenDomainContext _context;

    protected RepositoryBase(DrivenDomainContext context)
    {
        _context = context;
    }

    protected virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        try
        {
            var result = _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
        catch (Exception ex)
        {
            throw new NpgsqlException("Error on Create Method", ex);
        }

    }

    protected virtual async Task<IEnumerable<TEntity>> FindAllAsync(int page, int pageSize)
    {
        try
        {
            return await _context
                   .Set<TEntity>()
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize)
                   .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new NpgsqlException("Error on FindAllAsync", ex);
        }
    }
}