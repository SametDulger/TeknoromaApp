using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public Order AddOrderDetailInOrder(OrderDetail orderDetail)
        {
            return _orderDal.AddOrderDetailInOrder(orderDetail);
        }

        public void Create(Order entity)
        {
            _orderDal.Create(entity);
        }

        public bool CreateOrder(Order order)
        {
            return _orderDal.CreateOrder(order);
        }

        public void Delete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public List<Order> GetActive()
        {
            return _orderDal.GetActive();
        }

        public List<Order> GetByDefault(Expression<Func<Order, bool>> filter = null)
        {
            return _orderDal.GetByDefault(filter);
        }

        public Order GetById(Guid id)
        {
            return _orderDal.GetById(id);
        }

        public void Update(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}
