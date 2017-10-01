using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class MvcLogin
    {
        public MvcLogin()
        {
            Roles = new List<string>();
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}