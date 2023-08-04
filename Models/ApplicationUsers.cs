using Microsoft.AspNetCore.Identity;


namespace ByteBound.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public int ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; internal set; }
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string VerificationStatus { get; set; } = string.Empty;
        public int Score { get; set; }
        public string CardNumber { get; set; }
        public string CardCVV { get; set; }

        public DateTime CardExpiry { get; set; }

        public string SecurityQn { get; set; } = string.Empty;
        public string SecurityAns { get; set; } = string.Empty;
    }
}
