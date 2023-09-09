using System.ComponentModel.DataAnnotations;

namespace PlamoClubApi.Models;

public class Producer
{
  [Key]
  public Guid Id { get; set; }
  public string Name { get; set; }

  public Producer(string name)
  {
    Id = new Guid();
    Name = name;
  }
}