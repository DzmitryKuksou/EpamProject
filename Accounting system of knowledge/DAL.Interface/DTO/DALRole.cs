using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;

namespace DAL.Interface.DTO
{
    public class DALRole
    {
        public DALRole()
        {
            Login_Mail = new List<DALLogin>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DALLogin> Login_Mail { get; set; }
    }
}
