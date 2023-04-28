using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class SupplierExpenseReportDTO
    {
        public Guid ID { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime CreatedDate { get; set; }

        public int Total { get; set; }
    }
}
