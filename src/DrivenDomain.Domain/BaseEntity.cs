namespace Challenge.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}