namespace DrivenDomain.Application.Dtos;

public class CustomerDto : BaseDto
{
    public String Name { get; set; }
    public String Email { get; set; }
    public String Phone { get; set; }
    public String Type { get; set; }
}