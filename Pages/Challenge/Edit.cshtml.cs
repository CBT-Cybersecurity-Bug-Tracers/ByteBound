using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ByteBound.Data;
using ByteBound.Models;

namespace ByteBound.Pages.Challenge
{
    public class EditModel : PageModel
    {
        private readonly ByteBound.Data.ByteBoundContext _context;

        public EditModel(ByteBound.Data.ByteBoundContext context)
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

            var challenges =  await _context.Challenges.FirstOrDefaultAsync(m => m.ID == id);
            if (challenges == null)
            {
                return NotFound();
            }
            Challenges = challenges;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Challenges).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChallengesExists(Challenges.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChallengesExists(int id)
        {
          return (_context.Challenges?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
