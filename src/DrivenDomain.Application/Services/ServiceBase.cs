namespace DrivenDomain.Application.Services;

public abstract class ServiceBase<TEntity> where TEntity : class
{

    protected virtual Task<IEnumerable<TEntity>> Paginate(TEntity entity, int page, int pageSize)
    {
        
        
        return Task.FromResult<IEnumerable<TEntity>>(new List<TEntity>());
    }
}