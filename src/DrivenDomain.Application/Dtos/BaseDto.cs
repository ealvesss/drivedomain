namespace DrivenDomain.Application.Dtos;

public abstract class BaseDto
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
}