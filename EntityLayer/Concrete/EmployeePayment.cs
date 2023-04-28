using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Concrete
{
    public class EmployeePayment : BaseEntity
    {
        public EmployeePayment()
        {
            PaymentDate = DateTime.Now;
        }

        [Display(Name = "Tutar")]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }


        [Display(Name = "Euro")]
        [Column(TypeName = "money")]
        public decimal Euro { get; set; }


        [Display(Name = "Dolar")]
        [Column(TypeName = "money")]
        public decimal Dolar { get; set; }

        [Display(Name = "Açıklama")]
        [Column(TypeName = "nvarchar(250)")]
        public string Explanation { get; set; }


        [Display(Name = "Ödeme Tarihi")]
        public DateTime PaymentDate { get; set; }


        public AppUser AppUser { get; set; }


        public Guid AppUserId { get; set; }

    }
}
