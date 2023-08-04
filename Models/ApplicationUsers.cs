using Microsoft.AspNetCore.Identity;


namespace ByteBound.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string SecurityAns { get; set; } = string.Empty;
        public string SecurityQn { get; set; } = string.Empty;
    }
}
