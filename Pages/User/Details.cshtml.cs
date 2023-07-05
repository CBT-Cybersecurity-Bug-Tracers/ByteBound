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

      public Users Users { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
            if (users == null)
            {
                return NotFound();
            }
            else 
            {
                Users = users;
            }
            return Page();
        }
    }
}
