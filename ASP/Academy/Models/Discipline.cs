using System.ComponentModel.DataAnnotations;

namespace Academy.Models;

public class Discipline
{
    [Key]
    public short discipline_id { get; set; }
    [Required]
    public required string discipline_name { get; set; }
    [Required]
    public byte number_of_lessons { get; set; }

    //Navigation Property

}
