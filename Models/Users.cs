﻿using System.ComponentModel.DataAnnotations;

namespace ByteBound.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string VerificationStatus { get; set; } = string.Empty;
        public decimal Score { get; set; }
        public decimal CardNumber { get; set; }
        public decimal CardCVV { get; set; }

        [DataType(DataType.Date)]
        public DateTime CardExpiry { get; set; }
    }
}
