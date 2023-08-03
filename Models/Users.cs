using System.ComponentModel.DataAnnotations;

namespace ByteBound.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string UserName { get; internal set; }
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string VerificationStatus { get; set; } = string.Empty;
        public int Score { get; set; }
        public string CardNumber { get; set; }
        public string CardCVV { get; set; }

        [DataType(DataType.Date)]
        public DateTime CardExpiry { get; set; }
    }
}
