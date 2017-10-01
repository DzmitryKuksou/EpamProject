using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;

namespace DAL.Interface.DTO
{
    public class DALSphere
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
    }
}
