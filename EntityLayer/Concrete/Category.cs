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
    public class Category : BaseEntity
    {
        [Display(Name = "Kategori Adı")]
        [Column(TypeName = "nvarchar(250)")]
        public string CategoryName { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Kategori Açıklaması")]
        public string Description { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }

    }
}
