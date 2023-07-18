using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ByteBound.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
