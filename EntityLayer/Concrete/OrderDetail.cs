using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Concrete
{
    public class OrderDetail : BaseEntity
    {
        [Display(Name = "Tutar")]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Adet")]
        public int Quantity { get; set; }


        public Guid ProductId { get; set; }


        [Display(Name = "Ürün")]
        public Product Product { get; set; }


        public Guid OrderId { get; set; }


        [Display(Name = "Sipariş")]
        public Order Order { get; set; }

    }
}
