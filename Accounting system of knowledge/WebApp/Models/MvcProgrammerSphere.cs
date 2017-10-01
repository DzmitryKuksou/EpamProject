using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class MvcProgrammerSphere
    {
        public MvcProgrammerSphere()
        {
            Spheres = new List<MvcSphere>();
        }
        public int Id { get; set; }
        public int IdProgrammer { get; set; }
        public string Login { get; set; }
        public int IdSphere { get; set; }
        public List<MvcSphere> Spheres { get; set; }
    }
}