using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models;

public class Student
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int stud_id { get; set; }
    [Required]
    public required string last_name { get; set; }
    public required string first_name { get; set; }
    public string? middle_name { get; set; }
    [DataType(DataType.Date)]
    public required DateOnly birth_date { get; set; }
    [Required]
    [ForeignKey("Group")]
    public required int group {  get; set; }
    public required Group Group { get; set; }
}
