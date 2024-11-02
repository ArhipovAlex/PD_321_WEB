using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace ContosoUniversity.Models;

public class Instructor
{
    public int ID { get; set; }
    [Required]
    [Display(Name ="Фамилия")]
    [StringLength(50)]
    [RegularExpression("^[A-ZА-Я]+[a-zа-я]*$")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Имя")]
    [StringLength(50)]
    [RegularExpression("^[A-ZА-Я]+[a-zа-я]*$")]
    [Column("FirstName")]//свойство FirstMidName связано с полем таблицы БД "FirstName"
    public string FirstMidName { get; set; }

    [Display(Name ="Дата трудоустройства")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
    public DateTime HireDate { get; set; }
    public string FullName
    {
        get=>$"{LastName} {FirstMidName}";
    }
    //Navigation property:
    public ICollection<Course> Courses { get; set; }
    public OfficeAssigment OfficeAssigment { get; set; }
}
