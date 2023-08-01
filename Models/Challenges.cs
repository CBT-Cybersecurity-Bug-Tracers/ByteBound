using System.ComponentModel.DataAnnotations;

namespace ByteBound.Models
{
    public class Challenges
    {
        public int ID { get; set; }
        public string ChallengeName { get; set; } = string.Empty;
        public string ChallengeAnswer { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Points { get; set; }
    }
}
