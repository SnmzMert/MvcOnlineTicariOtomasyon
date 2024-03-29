using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Expenses
    {
        public int Id { get; set; } 
        public string Description {  get; set; }
        public DateTime date { get; set; }
        public Decimal Price {  get; set; } 

    }
}  