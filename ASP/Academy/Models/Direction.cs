using System.ComponentModel.DataAnnotations;

namespace Academy.Models;

public class Direction
{
    [Key] 
    public byte direction_id {get; set; }
    [Required]
    public required string direction_name {get; set; }

    public ICollection<Group>? Groups { get; set; }

    public ICollection<DirectionsDisciplinesRelations>? Disciplines { get; set; }
}
