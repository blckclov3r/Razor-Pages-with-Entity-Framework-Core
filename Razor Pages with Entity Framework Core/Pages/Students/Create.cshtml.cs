using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor_Pages_with_Entity_Framework_Core.Data;
using Razor_Pages_with_Entity_Framework_Core.Models;

namespace Razor_Pages_with_Entity_Framework_Core.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext _context;

        public CreateModel(Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        //[BindProperty]
        //public Models.Student Student { get; set; }

        public class StudentVM
        {
            public int ID { get; set; }
            public string LastName { get; set; }
            public string FirstMidName { get; set; }
            public DateTime EnrollmentDate { get; set; }
        }

        [BindProperty]
        public StudentVM studentVM { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //var emptyStudent = new Models.Student();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //if(await TryUpdateModelAsync<Models.Student>(
            //      emptyStudent,"student",s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            //{
            //    _context.Students.Add(Student);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}
            //return Page();

            var entry = _context.Add(new Models.Student());
            entry.CurrentValues.SetValues(studentVM);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
