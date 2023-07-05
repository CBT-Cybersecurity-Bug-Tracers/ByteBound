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
    public class IndexModel : PageModel
    {
        private readonly ByteBound.Data.ByteBoundContext _context;

        public IndexModel(ByteBound.Data.ByteBoundContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                Users = await _context.Users.ToListAsync();
            }
        }
    }
}
