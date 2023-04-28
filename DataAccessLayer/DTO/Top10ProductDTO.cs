using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class Top10ProductDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int TotalSell { get; set; }

        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }

    }
}
