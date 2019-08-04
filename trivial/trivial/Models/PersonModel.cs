using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivial.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public string FisrtSurname { get; set; }
        public string SecondSurname { get; set; }
        public EnumSex Sex { get; set; }
    }
}
