using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class MvcCategory
    {
        public MvcCategory()
        {
            Sphere = new List<MvcSphere>();
        }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        [StringLength(50, ErrorMessage = "Max length 50")]
        [Required(ErrorMessage = "Please, enter name")]
        public string Name { get; set; }
        public List<MvcSphere> Sphere { get; set; }
    }
}