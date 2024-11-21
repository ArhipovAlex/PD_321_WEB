using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models;

//PJT - Pure Join Table
[PrimaryKey(nameof(teacher), nameof(discipline))]
public class TeachersDisciplinesRelations//:IComparable
{
    [ForeignKey("Teacher")]

    public int teacher { get; set; }
    [ForeignKey("Discipline")]
    public short discipline { get; set; }

    //Navigation properties:
    public Teacher Teacher { get; set; }
    public Discipline Discipline { get; set; }

    //public int CompareTo(object other)
    //{
    //    return teacher.CompareTo((other as TeachersDisciplinesRelations).teacher)+
    //        discipline.CompareTo((other as TeachersDisciplinesRelations).discipline);
    //}

    public static bool operator==(TeachersDisciplinesRelations left, TeachersDisciplinesRelations right)
    {
        return left.teacher == right.teacher && left.discipline == right.discipline;
    }
    public static bool operator!=(TeachersDisciplinesRelations left, TeachersDisciplinesRelations right)
    {
        return left.teacher != right.teacher && left.discipline == right.discipline;
    }
    public override bool Equals(object? obj)
    {
        return this.teacher==(obj as TeachersDisciplinesRelations).teacher &&
            this.discipline==(obj as TeachersDisciplinesRelations).discipline;
    }
}