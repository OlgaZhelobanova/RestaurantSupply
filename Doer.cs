using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class DoerBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Login { get; set; }

        public int? Password { get; set; }

        public DoerBLL() { }

        public DoerBLL(Doer d)
        {
            Id = d.Id;
            Name = d.Name;
            Login = d.Login;
            Password = d.Password;
        }
    }
}
