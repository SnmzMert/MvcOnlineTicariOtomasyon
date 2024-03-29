using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CommandType
    {
        public int Id { get; set; }
        public string CommandName { get; set; }
        public ICollection<Command>Commands { get; set; }   
    }
}