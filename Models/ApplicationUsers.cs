using Microsoft.AspNetCore.Identity;


namespace ByteBound.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
