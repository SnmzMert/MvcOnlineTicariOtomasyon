using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; } 
        //ürünad
        //cariad
        //personelad
       public DateTime Date { get; set; }
        public int Amount {  get; set; }
        public decimal Price {  get; set; } 
        public decimal TotalPrice {  get; set; }
        public bool IsLocked { get; set; }
       
        public virtual Product Product {  get; set; }
        public virtual Current Current { get; set; }
        public  virtual Employee Employee { get; set; }
        public int Productid {  get; set; }
        public int Currentid {  get; set; }
        public int Employeeid {  get; set; }
        






    }
}