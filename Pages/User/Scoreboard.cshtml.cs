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
    public class ScoreboardModel : PageModel
    {
        private readonly ByteBound.Data.ByteBoundContext _context;

        public ScoreboardModel(ByteBound.Data.ByteBoundContext context)
        {
            _context = context;
        }

        public IList<ApplicationUsers> ApplicationUsers { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ApplicationUsers != null)
            {
                ApplicationUsers = await _context.ApplicationUsers.ToListAsync();
            }
        }
    }
}
