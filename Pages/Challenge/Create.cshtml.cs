using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ByteBound.Data;
using ByteBound.Models;

namespace ByteBound.Pages.Challenge
{
    public class CreateModel : PageModel
    {
        private readonly ByteBound.Data.ByteBoundContext _context;

        public CreateModel(ByteBound.Data.ByteBoundContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Challenges Challenges { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Challenges == null || Challenges == null)
            {
                return Page();
            }

            _context.Challenges.Add(Challenges);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
