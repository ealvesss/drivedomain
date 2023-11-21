namespace DrivenDomain.Application.Dtos.Request;

public class CreateRequestDto
{
    public String Name { get; set; }
    public String Email { get; set; }
    public String Phone { get; set; }
    public String Document { get; set; }
    public String Address { get; set; }
    public String Type { get; set; }
}