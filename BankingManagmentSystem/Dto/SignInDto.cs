using System;
using System.ComponentModel.DataAnnotations;

namespace BankingManagmentSystem.Dto
{
    public class SignInDto
    {
        [Required]
        [RegularExpression(@"\S+@\S+.\S+")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Password { get; set; }
    }
}

