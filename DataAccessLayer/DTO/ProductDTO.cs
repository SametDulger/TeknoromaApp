using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnıtsInStock { get; set; }

    }
}
