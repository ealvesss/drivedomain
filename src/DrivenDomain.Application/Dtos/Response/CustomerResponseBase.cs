namespace DrivenDomain.Application.Dtos.Response;

public abstract class ResponseBase<TEntity> where TEntity : class
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public IEnumerable<TEntity> Data { get; set; } = new List<TEntity>();
}