using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }
        
        public string PromotionName { get; set; }

        public virtual Product Product { get; set; }
        public int Productid { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string SerialNumber { get; set; }
        
        public int PromotionPoint {  get; set; }


    }
}