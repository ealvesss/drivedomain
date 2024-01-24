namespace DrivenDomain.Application.Dtos.Response.Customer;

public class CustomerResponseBase<TEntity> where TEntity : class
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public IEnumerable<TEntity> Data { get; set; } = new List<TEntity>();
}