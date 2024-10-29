using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }
        public string LastNameSort {  get; set; }
        public string FirstNameSort {  get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter {  get; set; }
        public string CurrentSort { get; set; }
        public IList<Student> Students { get;set; } = default!;

        public async Task OnGetAsync( string sortOrder, string searchString)
        {
            LastNameSort = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";//Descinding by Name
            FirstNameSort = sortOrder=="first_name" ? "first_name_desc" : "first_name";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Student> students = from s in _context.Students select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(
                        s=>s.LastName.Contains(searchString)
                        ||s.FirstName.Contains(searchString)
                );
            }
            
            switch(sortOrder)
            {
                case "last_name_desc":   students = students.OrderByDescending(s => s.LastName);     break;
                case "first_name_desc": students=students.OrderByDescending(s => s.FirstName); break;
                case "first_name": students = students.OrderBy(s => s.FirstName); break;
                case "Date":        students = students.OrderBy(s => s.EnrollmentDate);         break;
                case "date_desc":   students = students.OrderByDescending(s => s.EnrollmentDate); break;
                default:            students = students.OrderBy(s => s.LastName);               break;
            }
            Students = await students.ToListAsync();
        }
    }
}
