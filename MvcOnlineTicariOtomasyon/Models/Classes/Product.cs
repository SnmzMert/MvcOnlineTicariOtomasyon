using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName="varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public short StokAmount { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsActive { get; set; }
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
           
        public ICollection<Transaction>Transactions { get; set; }
        public ICollection<Command>Commands { get; set; }


    }
} 