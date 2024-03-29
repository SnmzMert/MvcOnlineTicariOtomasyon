using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Command
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductAmount {  get; set; }
        public Current Current { get; set; }    
        public Employee Employee { get; set; }  
        public CommandType CommandType { get; set; }
        public int CreaterCommand { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsApproved { get; set; }

    }
}