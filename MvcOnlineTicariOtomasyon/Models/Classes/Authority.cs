using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Authority
    {
        [Key]
        public int AuthorityId { get; set; }
        public string AuthorityName { get; set; }

        public ICollection<Admin>Admins { get; set; }   
    }
}