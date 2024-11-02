using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models;

public class Student
{
    public int ID { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "Too many sympols for Last Name")]
    [RegularExpression(@"^[A-ZА-Я]+[a-zа-я]*$")]
    [Display(Name = "Фамилия")]
    public string LastName { get; set; }
    [Required]
    [StringLength(50,ErrorMessage="Too many sympols for First Name")]
    [RegularExpression(@"^[A-ZА-Я]+[a-zа-я]*$")]
    [Column("first_name")]//свойство связано с полем таблицы БД "first_name"
    [Display(Name = "Имя")]
    public string FirstName { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
    [Display(Name = "Дата поступления")]
    public DateTime EnrollmentDate { get; set; }
    [Display(Name ="Полное имя")]
    public string FullName //Calculated Property
    {
        get=>$"{LastName} {FirstName}";
    }
    //Navigation Properties:
    public ICollection<Enrollment> Enrollments { get; set; }
}
