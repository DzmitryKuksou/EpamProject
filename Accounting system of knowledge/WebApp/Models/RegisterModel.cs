using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApp.Models
{
    public class RegisterModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Enter your login")]
        [Required(ErrorMessage = "Please, enter login")]
        public string Login { get; set; }
        [Display(Name = "Enter your email")]
        [Required(ErrorMessage = "Please, enter email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "please, Enter correct email ")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        [StringLength(30, ErrorMessage = "Max 50, Min 8", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password.  ")]
        [Compare("Password", ErrorMessage = "Passwords must be equals!")]
        public string ConfirmPassword { get; set; }
    }
}