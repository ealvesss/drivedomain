using System.Dynamic;

namespace Challenge.Application.Dtos;

public class BaseDto
{
  private Guid _id = Guid.NewGuid();
  
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  
  public Guid Id
  {
    get => _id;
    set => _id = value;
  }
}