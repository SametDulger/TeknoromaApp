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
    public class SupplierExpense : BaseEntity
    {
        [Display(Name = "Fiyat")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Display(Name = "Adet")]
        public short Quantity { get; set; }

        [Display(Name = "Toplam Fiyat")]
        public decimal TotalPrice { get => Price * Quantity; }


        public Guid ProductId { get; set; }


        public Product Product { get; set; }
    }
}
