using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivial.Models
{
    public class UserModel : PersonModel
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ConectionTry { get; set; }
        public DateTime LastDateConnection { get; set; }
        //public Status status { get; set; }
        //public Rol Rol { get; set; }
    }
}
