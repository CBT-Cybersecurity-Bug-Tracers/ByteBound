using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ByteBound.Data;
using CBT.Models;

namespace ByteBound.Pages.Challenge
{
    public class DeleteModel : PageModel
    {
        private readonly ByteBound.Data.ByteBoundContext _context;

        public DeleteModel(ByteBound.Data.ByteBoundContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Challenges Challenges { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Challenges == null)
            {
                return NotFound();
            }

            var challenges = await _context.Challenges.FirstOrDefaultAsync(m => m.ID == id);

            if (challenges == null)
            {
                return NotFound();
            }
            else 
            {
                Challenges = challenges;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Challenges == null)
            {
                return NotFound();
            }
            var challenges = await _context.Challenges.FindAsync(id);

            if (challenges != null)
            {
                Challenges = challenges;
                _context.Challenges.Remove(Challenges);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
