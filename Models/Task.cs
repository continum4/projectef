using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectef.Models;

//[Table("Tasks")]
public class Task
{
  //[Key]
  public Guid TaskId {get; set;}

  //[ForeignKey("CategoryId")]
  public Guid CategoryId {get; set;}

  //[Required]
  //[MaxLength(200)]
  public string? Title  {get; set;}

  public string? Description {get; set;}

  public Priority Priority {get; set;}

  public DateTime CreatedAt {get; set;}

  public virtual Category Category {get; set;} = default!;

  //[NotMapped]
  public string? Summary {get; set;}
}

public enum Priority
{
  Baja,
  Media,
  Alta,
}