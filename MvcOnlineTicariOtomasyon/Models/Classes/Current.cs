using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentId { get; set; }
       
        [Column(TypeName = "varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karekter Yazabilirsiniz"),Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        public string CurrentName { get; set; }
        
        [Column(TypeName = "varchar")]
        [StringLength(100,ErrorMessage ="En Fazla 100 Karekter Yazabilirsiniz")]
        public string Description { get; set; }
       
        [Column(TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "En Fazla 20 Karekter Yazabilirsiniz"), Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string City { get; set; }
       
        [Column(TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karekter Yazabilirsiniz"), Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string Country { get; set; }
      
        [Column(TypeName = "varchar")]
        [StringLength(19), Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string Phone { get; set; }
      
        [Column(TypeName = "varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karekter Yazabilirsiniz"), Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string TaxOffice { get; set; }
      
        [Column(TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karekter Yazabilirsiniz"), Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string Mail { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 20 Karekter Yazabilirsiniz"), Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string Password { get; set; }


        public decimal CurrentAmount { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Billing> Billings { get; set; }
        public ICollection<Command> Commands { get; set; }


    }
}
                                                                                   