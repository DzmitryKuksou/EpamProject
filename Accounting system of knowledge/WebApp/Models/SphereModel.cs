using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class SphereModel
    {
        public SphereModel()
        {
            Spheres = new List<MvcSphere>();
        }
        public int ProgId { get; set; }
        public List<MvcSphere> Spheres { get; set; }
    }
}