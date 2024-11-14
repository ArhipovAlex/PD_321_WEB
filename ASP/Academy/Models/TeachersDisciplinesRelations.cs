using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models;

//PJT - Pure Join Table
[PrimaryKey (nameof(teacher),nameof(discipline))]
public class TeachersDisciplinesRelations
{
    [ForeignKey("Teacher")]

    public int teacher { get; set; }
    [ForeignKey("Discipline")]
    public short discipline { get; set; }

    //Navigation properties:
    public required Teacher Teacher { get; set; }
    public required Discipline Discipline { get; set; }
}
