using EntityLayer.Abstract;
using EntityLayer.Enum;
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
    public class Issue : BaseEntity
    {
        [Display(Name = "Konu")]
        [Column(TypeName = "nvarchar(250)")]
        public string Subject { get; set; }

        [Display(Name = "Problem")]
        [Column(TypeName = "nvarchar(1000)")]
        public string Problem { get; set; }

        [Display(Name = "Cevap")]
        [Column(TypeName = "nvarchar(1000)")]
        public string Answer { get; set; }


        [Display(Name = "Kayıt Durumu")]
        public IssueStatus IssueStatus { get; set; }


        public AppUser AppUser { get; set; }


        public Guid AppUserId { get; set; }
    }
}
