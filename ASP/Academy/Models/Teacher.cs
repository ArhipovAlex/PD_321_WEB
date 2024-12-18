﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models;

public class Teacher
{
    [Key]
    public int teacher_id { get; set; }
    [Required]
    public required string last_name { get; set; }
    public required string first_name { get; set; }
    public string? middle_name { get; set; }
    [DataType(DataType.Date)]
    public required DateOnly birth_date { get; set; }
    public required DateOnly work_since { get; set; }

    //Navigation properties:
    public ICollection<TeachersDisciplinesRelations>? Disciplines { get; set; }
    //public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectList>? DisciplinesToEnum 
    //{
    //    get => new SelectList(Microsoft.AspNetCore.Mvc.Rendering.SelectList(Disciplines)); 
    //} 
}
