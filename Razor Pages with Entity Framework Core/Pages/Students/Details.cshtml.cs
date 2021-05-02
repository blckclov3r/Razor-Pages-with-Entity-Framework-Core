using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Pages_with_Entity_Framework_Core.Data;
using Razor_Pages_with_Entity_Framework_Core.Models;

namespace Razor_Pages_with_Entity_Framework_Core.Pages.Student
{
    public class DetailsModel : PageModel
    {
        private readonly Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext _context;

        public DetailsModel(Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext context)
        {
            _context = context;
        }

        public Models.Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Student = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
