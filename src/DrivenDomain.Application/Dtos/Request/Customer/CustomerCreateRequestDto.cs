namespace DrivenDomain.Application.Dtos.Request.Customer;

public class CustomerCreateRequestDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }
}