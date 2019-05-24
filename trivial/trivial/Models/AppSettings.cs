using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivial.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string Urls { get; set; }
        public string SackBarcodeRegex { get; set; }
        public bool UseOPC { get; set; }
    }
}
