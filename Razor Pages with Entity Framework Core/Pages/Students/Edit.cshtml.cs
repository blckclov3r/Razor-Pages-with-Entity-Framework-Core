using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_Pages_with_Entity_Framework_Core.Data;
using Razor_Pages_with_Entity_Framework_Core.Models;

namespace Razor_Pages_with_Entity_Framework_Core.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext _context;

        public EditModel(Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Student = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);

            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Student).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StudentExists(Student.StudentID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");

            var studentToUpdate = await _context.Students.FindAsync(id);
           if(studentToUpdate == null)
            {
                return NotFound();
            }
             
            if(await TryUpdateModelAsync<Models.Student>
                (studentToUpdate,"student",
                s=>s.LastName,
                s => s.FirstMidName,
                s =>s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }
    }
}
