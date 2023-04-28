using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace EntityLayer.Concrete
{
    public class Product : BaseEntity
    {
        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [Display(Name = "Stok Miktarı")]
        public int UnıtsInStock { get; set; }

        [Display(Name = "Fiyat")]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Barkod Numarası")]
        public string BarcodeNumber { get; set; }

        [Display(Name = "Ürün Resmi")]
        public string ImageName { get; set; }

        [NotMapped]
		[Display(Name = "Ürün Resim Dosyası")]
		public IFormFile ImageFile { get; set; }


        public Guid SubCategoryId { get; set; }


        [Display(Name = "Alt Kategori")]
        public SubCategory SubCategory { get; set; }


        public Guid SupplierId { get; set; }


        [Display(Name = "Tedarikçi")]
        public Supplier Supplier { get; set; }


        public virtual List<OrderDetail> OrderDetails { get; set; }


        public virtual List<SupplierExpense> SupplierExpenses { get; set; }

    }
}
