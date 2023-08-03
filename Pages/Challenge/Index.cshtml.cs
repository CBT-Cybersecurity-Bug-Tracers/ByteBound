using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ByteBound.Data;
using ByteBound.Models;

namespace ByteBound.Pages.Challenge
{
    public class IndexModel : PageModel
    {
        private readonly ByteBound.Data.ByteBoundContext _context;

        public IndexModel(ByteBound.Data.ByteBoundContext context)
        {
            _context = context;
        }

        public IList<Challenges> Challenges { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Challenges != null)
            {
                Challenges = await _context.Challenges.ToListAsync();
            }
        }
    }
}
