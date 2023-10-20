using System.ComponentModel.DataAnnotations;

namespace entityf.Data.Users
{
    public class ApiUserLog
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
