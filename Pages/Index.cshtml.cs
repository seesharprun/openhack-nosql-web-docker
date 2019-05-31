using Compose.Web.Context;
using Compose.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compose.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EmploymentContext _context;

        [BindProperty]
        public List<Company> Companies { get; } = new List<Company>();

        public IndexModel(EmploymentContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {
            Companies.Clear();
            Companies.AddRange(
                await _context.Companies
                    .OrderBy(c => c.Id)
                    .Take(25)
                    .ToListAsync<Company>()
            );
        }
    }
}