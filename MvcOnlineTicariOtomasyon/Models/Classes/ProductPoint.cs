using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class ProductPoint
    {
        [Key]
        public int ProductPointId { get; set; }
        public virtual Product Product { get; set; }
        public int Productid { get; set; }


        public int ProdductPoint { get; set; }

    }
}