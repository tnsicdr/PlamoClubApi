using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlamoClubApi.Models;

public class ModelKit
{
  [Key]
  public Guid Id { get; set; }
  public string Name { get; set; }

  [ForeignKey("Producer")]
  public Guid? ProducerId { get; set; }
  public virtual Producer? Producer { get; set; }

  public ModelKit(string name)
  {
    Id = new Guid();
    Name = name;
  }
}