using System;
using System.ComponentModel.DataAnnotations;

namespace BankingManagementSystem.Dto
{
    public class SignInDto
    {
        [Required]
        [RegularExpression(@"\S+@\S+.\S+")]
        public string Username { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Password { get; set; }
    }
}

