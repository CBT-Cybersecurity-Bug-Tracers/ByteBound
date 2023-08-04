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

namespace ByteBound.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly ByteBound.Data.ByteBoundContext _context;

        public EditModel(ByteBound.Data.ByteBoundContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUsers ApplicationUsers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }

            var ApplicationUsers =  await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.ID == id);
            if (ApplicationUsers == null)
            {
                return NotFound();
            }
            ApplicationUsers = ApplicationUsers;
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

            _context.Attach(ApplicationUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUsersExists(ApplicationUsers.ID))
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

        private bool ApplicationUsersExists(int id)
        {
          return (_context.ApplicationUsers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
