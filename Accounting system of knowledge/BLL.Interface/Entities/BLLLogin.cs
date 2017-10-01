﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BLLLogin
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int IdProgrammer { get; set; }
        public int IdRole { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}