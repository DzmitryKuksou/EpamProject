using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DALProgrammer_Sphere
    {
        public DALProgrammer_Sphere()
        {
            Spheres = new List<DALSphere>();
        }
        public int Id { get; set; }
        public int IdProgrammer { get; set; }
        public string Login { get; set; }
        public int IdSphere { get; set; }
        public List<DALSphere> Spheres { get; set; }
    }
}
