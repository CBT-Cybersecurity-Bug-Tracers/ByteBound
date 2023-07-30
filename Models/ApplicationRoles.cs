using Microsoft.AspNetCore.Identity;

namespace ByteBound.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; } =
       string.Empty;
        public DateTime CreatedDate { get; set; }
        public string IPAddress { get; set; } = string.Empty;
    }
}
