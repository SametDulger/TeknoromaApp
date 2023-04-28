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
    public class Supplier : BaseEntity
    {
        [Display(Name = "Şirket Adı")]
        [Column(TypeName = "nvarchar(250)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "İletişim Adı")]
        public string ContactName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Mail Adresi")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }


        public virtual List<Product> Products { get; set; }

    }
}
