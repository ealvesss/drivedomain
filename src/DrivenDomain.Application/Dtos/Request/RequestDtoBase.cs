namespace DrivenDomain.Application.Dtos.Request;

public class RequestDtoBase
{
    public string OrderBy { get; set; } = null!;
    public int Page { get; set; }
    public int PageSize { get; set; }
}