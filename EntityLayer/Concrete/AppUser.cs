using EntityLayer.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<Guid>
    {
        public Status Status { get; set; }
        [Display(Name = "Ad")]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }


        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Adres")]
        public string Address { get; set; }


        [Column(TypeName = "nvarchar(256)")]
        [Display(Name = "Parola")]
        public string Password { get; set; }


        [Display(Name = "Maaş")]
        [Column(TypeName = "Money")]
        public decimal Salary { get; set; }


        [Display(Name = "Bonus")]
        [Column(TypeName = "money")]
        public decimal Bonus { get; set; }


        [Display(Name = "Aylık Satış")]
        [Column(TypeName = "money")]
        public decimal MonthlySales { get; set; }



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

        public List<Order> Orders { get; set; }
        public List<Issue> Issues { get; set; }
        public List<Expense> Expenses { get; set; }

    }
}
