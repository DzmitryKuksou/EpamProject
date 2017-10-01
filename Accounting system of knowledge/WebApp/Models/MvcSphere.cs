using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class MvcSphere
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Sphere Name")]
        [StringLength(50, ErrorMessage = "Max length 50")]
        [Required(ErrorMessage = "Please, enter your name")]
        public string Name { get; set; }
        public int Level { get; set; }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Choose sphere category")]
        public string CategoryName { get; set; }
    }
}