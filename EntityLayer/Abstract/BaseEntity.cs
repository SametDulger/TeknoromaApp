using EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Abstract
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        [Display(Name = "#")]
        public int MasterId { get; set; }


        [Display(Name = "Durum")]
        public Status Status { get; set; } = Status.Active;


        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }


        [Display(Name = "Oluşturulan Bilgisayarın Adı")]
        public string CreatedComputerName { get; set; }


        [Display(Name = "Oluşturan Bilgisayarın IP Adresi")]
        public string CreatedIP { get; set; }


        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatedBy { get; set; }


        [Display(Name = "Güncelleme Tarihi")]
        public DateTime UpdatedDate { get; set; }


        [Display(Name = "Güncellenen Bilgisayarın Adı")]
        public string UpdatedComputerName { get; set; }


        [Display(Name = "Güncellenen Bilgisayarın IP Adresi")]
        public string UpdatedIP { get; set; }


        [Display(Name = "Güncelleyen Kullanıcı")]
        public string UpdatedBy { get; set; }

    }
}
