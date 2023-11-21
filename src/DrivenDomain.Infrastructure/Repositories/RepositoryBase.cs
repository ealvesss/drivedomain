namespace DrivenDomain.Infrastructure;

public abstract class RepositoryBase<TEntity> where TEntity : class
{
    private readonly DrivenDomainContext _context;
    
    public RepositoryBase(DrivenDomainContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> Add(TEntity entity)
    {
        var result = await _context.Set<TEntity>().AddAsync(entity);
        return result.Entity;
    }
}