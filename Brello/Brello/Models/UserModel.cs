using System.ComponentModel.DataAnnotations;

namespace Brello.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PreferredCurrency { get; set; } = "NRS"; // Default value
    }
}
