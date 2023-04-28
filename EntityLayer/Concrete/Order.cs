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
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }

        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }


        [Display(Name = "Sipariş Durumu")]
        public OrderStatus OrderStatus { get; set; }


        public Guid AppUserId { get; set; }


        [Display(Name = "Personel")]
        public AppUser AppUser { get; set; }


        [Display(Name = "Müşteri")]
        public Customer Customer { get; set; }


        public Guid CustomerId { get; set; }


        [Display(Name = "Kasa No")]
        [Column(TypeName = "nvarchar(50)")]
        public string CaseNo { get; set; }


        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
