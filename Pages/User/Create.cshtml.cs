using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ByteBound.Data;
using ByteBound.Models;
using Microsoft.AspNetCore.Identity;

namespace ByteBound.Pages.User
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
        public ApplicationUsers ApplicationUsers { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ApplicationUsers == null || ApplicationUsers == null)
            {
                return Page();
            }

            _context.ApplicationUsers.Add(ApplicationUsers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
