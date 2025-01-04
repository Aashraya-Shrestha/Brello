using System.ComponentModel.DataAnnotations;

namespace Brello.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
