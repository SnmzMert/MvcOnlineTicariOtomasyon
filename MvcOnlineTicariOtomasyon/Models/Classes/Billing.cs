using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Channels;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Billing
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string SerialNumber { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Description { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string TaxOffice { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string Time { get; set; }

        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Sum { get; set; }

        public int Employeeid { get; set; }

        public virtual Employee Employee { get; set; }
        public int Currentid { get; set; }

        public virtual Current Current { get; set; }
        public int Transacationid {  get; set; }

        

        public ICollection<BillingDetail> BillingDetails { get; set; }
        
        
        //sender
        //reciever




    }
}