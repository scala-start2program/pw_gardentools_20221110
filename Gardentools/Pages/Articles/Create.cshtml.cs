using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gardentools.Data;
using Gardentools.Models;

namespace Gardentools.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly Gardentools.Data.GardentoolsContext _context;

        public CreateModel(Gardentools.Data.GardentoolsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BrandId"] = new SelectList(_context.Set<Brand>(), "Id", "BrandName");
        ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Article.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
