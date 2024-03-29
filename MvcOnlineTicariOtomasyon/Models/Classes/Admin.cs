using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string UserName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string Password { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1)]
        public string Email { get; set; }
        
        
        public int Authorityid { get; set; }
        public virtual Authority Authority { get; set; }



    }
}