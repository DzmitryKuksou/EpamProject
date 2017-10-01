using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BLLCategory
    {
        public BLLCategory()
        {
            Sphere = new List<BLLSphere>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BLLSphere> Sphere{get;set;}
    }
}
