using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginModel
    {
        [Display(Name = "Email or Login")]
        [StringLength(50, ErrorMessage = "Maximum length of symbols is 50")]
        [Required(ErrorMessage = "Please enter your email or Login")]
        public string MailOrLogin { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Maximum length of symbols is 50, Minimum length of symbols is 6", MinimumLength = 6)]
        [Required(ErrorMessage = "Please, enter your password")]
        public string Password { get; set; }

    }
}