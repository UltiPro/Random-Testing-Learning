using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace entityf.Data.Users
{
    public class ApiUserReg
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Tak którkie hasełko {1} to {2}", MinimumLength = 6)]
        public string Password { get; set; }

    }
}
