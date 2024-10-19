using System.ComponentModel.DataAnnotations;

namespace BlazorAppPD_212.Models
{
    public class TeachersDisciplinesRelation
    {
        [Key]public int teacher { get; set; }
        [Key]public short discipline { get; set; }
    }
}
//https://stackoverflow.com/questions/74342264/the-entity-type-has-multiple-properties-with-the-key-attribute-composite-prim