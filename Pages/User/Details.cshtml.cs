using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ByteBound.Data;
using ByteBound.Models;

namespace ByteBound.Pages.User
{
    public class DetailsModel : PageModel
    {
        private readonly ByteBound.Data.ByteBoundContext _context;

        public DetailsModel(ByteBound.Data.ByteBoundContext context)
        {
            _context = context;
        }

      public ApplicationUsers ApplicationUsers { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }

            var ApplicationUsers = await _context.ApplicationUsers.FirstOrDefaultAsync(m => m.ID == id);
            if (ApplicationUsers == null)
            {
                return NotFound();
            }
            else 
            {
                ApplicationUsers = ApplicationUsers;
            }
            return Page();
        }
    }
}
