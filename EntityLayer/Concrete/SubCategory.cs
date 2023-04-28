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
    public class SubCategory : BaseEntity
    {
        [Display(Name = "Alt Kategori Adı")]
        [Column(TypeName = "nvarchar(50)")]
        public string SubCategoryName { get; set; }

        [Display(Name = "Açıklama")]
        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }


        public Guid CategoryId { get; set; }


        public Category Category { get; set; }


        public virtual List<Product> Products { get; set; }
    }
}
