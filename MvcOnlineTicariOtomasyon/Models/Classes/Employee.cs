using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string EmployeeImage { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Address { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(18)]
        public string Phone { get; set; }
        public int Departmentid { get; set; }
        public bool IsActive {  get; set; }
        public virtual Department Department  { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Billing> Billings { get; set; }
        public ICollection<Command> Commands { get; set; }  


    }
}