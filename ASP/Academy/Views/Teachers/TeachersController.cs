using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academy.Data;
using Academy.Models;

namespace Academy.Views.Teachers
{
    public class TeachersController : Controller
    {
        private readonly AcademyContext _context;

        public TeachersController(AcademyContext context)
        {
            _context = context;
        }
        public Teacher Teacher { get; set; } = default!;

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teachers.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .Include(t => t.Disciplines!)
                .ThenInclude(d => d.Discipline)
                .FirstOrDefaultAsync(m => m.teacher_id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("stud_id,last_name,first_name,middle_name,birth_date,work_since")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var teacher = await _context.Teachers.FindAsync(id);
            var teacher = await _context.Teachers
                .Include(t => t.Disciplines!)
                .ThenInclude(d => d.Discipline)
                .FirstOrDefaultAsync(m => m.teacher_id == id);

            var disciplines = await _context.Disciplines.ToListAsync();
            ViewData["Disciplines"] = new SelectList(disciplines, "discipline_id", "discipline_name");
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("stud_id,last_name,first_name,middle_name,birth_date,work_since")] Teacher teacher)
        {
            if (id != teacher.teacher_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    //_context.Update(teacher.Disciplines!);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.teacher_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Edit));
            }
            return View(teacher);
        }
        public async Task<IActionResult> AddDiscipline(int? teacher_id, short? discipline_id)
        {
            //int? teacher_id = teacher;
            //int? discipline_id = discipline;

            Teacher teacher = await _context.Teachers
                .Include(t => t.Disciplines)
                .ThenInclude(d => d.Discipline)
                .FirstOrDefaultAsync(m => m.teacher_id == teacher_id);
            List<Discipline> disciplines = _context.Disciplines.ToList();
            if (teacher == null) return Redirect("./Index");
            /////////////
            //DbSet<TeachersDisciplinesRelations> relations = _context.TeachersDisciplinesRelation;
            //HashSet<short> teachersDisciplines = new HashSet<short>(teacher.Disciplines.Select(d=>d.discipline));

            /////////////
            TeachersDisciplinesRelations disciplineToAdd = new TeachersDisciplinesRelations();
            disciplineToAdd.discipline=(short) discipline_id;
            disciplineToAdd.teacher=(int)teacher_id;
            disciplineToAdd.Discipline = await _context.Disciplines
                .FirstOrDefaultAsync(d => d.discipline_id == discipline_id);
            disciplineToAdd.Teacher = teacher;

            //bool exist = false;
            //foreach(TeachersDisciplinesRelations i in teacher.Disciplines)
            //{
            //    if (i == disciplineToAdd)
            //    {
            //        exist = true;
            //        break;
            //    }
            //}
            //if (!exist)
            //{            
            //    teacher.Disciplines.Add(disciplineToAdd); 

            //}
            if(teacher.Disciplines.Any(td=>td.discipline==disciplineToAdd.discipline))
            {
                //ModelState.AddModelError("", "Такая дисциплина уже есть");
                return RedirectToAction(nameof(Edit), new {id=teacher_id});
            }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(teacher);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TeacherExists(teacher.teacher_id)) return NotFound();
                        else throw;
                    }
                }
            return View(teacher);
            //return RedirectToPage("./Details", teacher.teacher_id);

            //if(discipline == null)
            //{
            //    //teacher.Disciplines = new List<TeachersDisciplinesRelations>();
            //    return;
            //}
            //teacher.Disciplines.Add
            //    (
            //    new TeachersDisciplinesRelations { teacher = teacher.teacher_id, discipline = discipline.discipline_id }
            //    );
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(m => m.teacher_id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.teacher_id == id);
        }
    }
}
