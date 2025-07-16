using System.ComponentModel.DataAnnotations;

namespace Master1Tech.Client.Shared
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}