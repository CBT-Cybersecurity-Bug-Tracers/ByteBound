using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CBT.Models;
using ByteBound.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ByteBound.Data
{
    public class ByteBoundContext : IdentityDbContext<ApplicationUsers, ApplicationRole, string>
    {
        public ByteBoundContext (DbContextOptions<ByteBoundContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<CBT.Models.Challenges> Challenges { get; set; } = default!;

        public DbSet<ByteBound.Models.Users>? Users { get; set; }
    }
}
