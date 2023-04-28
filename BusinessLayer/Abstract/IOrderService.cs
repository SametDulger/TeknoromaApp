using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        Order AddOrderDetailInOrder(OrderDetail orderDetail);

        bool CreateOrder(Order order);
    }
}
