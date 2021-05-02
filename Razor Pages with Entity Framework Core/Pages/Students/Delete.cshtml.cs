using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Razor_Pages_with_Entity_Framework_Core.Data;
using Razor_Pages_with_Entity_Framework_Core.Models;

namespace Razor_Pages_with_Entity_Framework_Core.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private readonly Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Models.Student Student { get; set; }

        public string ErrorMessage { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Student = await _context.Students.FirstOrDefaultAsync(m => m.StudentID == id);
            Student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.FindAsync(id);

            if (Student != null)
            {
                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
