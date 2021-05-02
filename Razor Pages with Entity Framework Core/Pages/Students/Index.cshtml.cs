using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Razor_Pages_with_Entity_Framework_Core.Data;
using Razor_Pages_with_Entity_Framework_Core.Models;

namespace Razor_Pages_with_Entity_Framework_Core.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext _context;
        private readonly MvcOptions _mvcOptions;

        public IndexModel(Razor_Pages_with_Entity_Framework_Core.Data.SchoolContext context, IOptions<MvcOptions> option)
        {
            _context = context;
            _mvcOptions = option.Value;

        }

        public IList<Models.Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students.Take(_mvcOptions.MaxModelBindingCollectionSize).ToListAsync();
        }
    }
}
