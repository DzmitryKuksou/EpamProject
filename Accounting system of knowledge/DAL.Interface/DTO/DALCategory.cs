using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DALCategory
    {
        public DALCategory()
        {
            this.Sphere = new List<DALSphere>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DALSphere> Sphere { get; set; }
    }
}
