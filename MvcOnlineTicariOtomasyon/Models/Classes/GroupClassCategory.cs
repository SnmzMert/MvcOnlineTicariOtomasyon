using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class GroupClassCategory
    {
        public string  Category { get; set; }
        public int IntegerValue { get; set; } // Tam sayı değeri için özellik
        public double DoubleValue { get; set; } // Ondalık sayı değeri için özellik
    }
}