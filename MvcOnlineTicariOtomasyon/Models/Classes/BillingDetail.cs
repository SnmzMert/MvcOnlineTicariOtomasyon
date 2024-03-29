using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class BillingDetail
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public int Amount {  get; set; }
        public decimal UnitPrice {  get; set; }
        public decimal Sum {  get; set; }
        public Billing Billing { get; set; }    
       
    }
}