using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BLLProgrammer_Sphere
    {
        public BLLProgrammer_Sphere()
        {
            Spheres = new List<BLLSphere>();
        }
        public int Id { get; set; }
        public int IdProgrammer { get; set; }
        public string Login { get; set; }
        public int IdSphere { get; set; }
        public List<BLLSphere> Spheres { get; set; }
    }
}
