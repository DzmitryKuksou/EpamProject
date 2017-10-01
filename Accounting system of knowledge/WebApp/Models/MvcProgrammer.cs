using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class MvcProgrammer
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "Max length - {50} symbols")]
        [Required(ErrorMessage = "Please, enter your name")]
        public string Name { get; set; }
        [Display(Name = "Surname")]
        [StringLength(50, ErrorMessage = "Max length - {50} symbols")]
        [Required(ErrorMessage = "Please, enter your surname")]
        public string Surname { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }
}