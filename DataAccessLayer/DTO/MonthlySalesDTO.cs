using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class MonthlySalesDTO
    {
        public DateTime OrderDate { get; set; }
        public string TCKN { get; set; }
        public string CustomerName { get; set; }
        public string EmployeUserName { get; set; }
        public decimal SalesTotal { get; set; }
        public Guid OrderId { get; set; }


    }
}
