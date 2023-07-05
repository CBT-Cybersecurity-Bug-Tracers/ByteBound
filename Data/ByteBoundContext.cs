using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CBT.Models;
using ByteBound.Models;

namespace ByteBound.Data
{
    public class ByteBoundContext : DbContext
    {
        public ByteBoundContext (DbContextOptions<ByteBoundContext> options)
            : base(options)
        {
        }

        public DbSet<CBT.Models.Challenges> Challenges { get; set; } = default!;

        public DbSet<ByteBound.Models.Users>? Users { get; set; }
    }
}
