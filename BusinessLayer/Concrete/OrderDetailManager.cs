using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void Create(OrderDetail entity)
        {
            _orderDetailDal.Create(entity);
        }

        public void Delete(OrderDetail entity)
        {
            _orderDetailDal.Delete(entity);
        }

        public List<OrderDetail> GetActive()
        {
           return _orderDetailDal.GetActive();
        }

        public List<OrderDetail> GetByDefault(Expression<Func<OrderDetail, bool>> filter = null)
        {
            return _orderDetailDal.GetByDefault(filter);
        }

        public OrderDetail GetById(Guid id)
        {
            return _orderDetailDal.GetById(id);
        }

        public void Update(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
        }
    }
}
