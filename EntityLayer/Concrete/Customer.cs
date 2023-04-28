using EntityLayer.Abstract;
using EntityLayer.Enum;
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
    public class Customer : BaseEntity
    {
        [Display(Name = "T.C. Kimlik Numarası")]
        public string TC { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Mail Adresi")]
        public string EmailAddress { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }

        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }
    }
}
