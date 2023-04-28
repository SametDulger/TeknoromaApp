using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrderDal : IOrderDal
    {
        private readonly Context _context;
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly IProductDal _productDal;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomerDal _customerDal;
        private readonly IAppUserDal _appUserDal;

        public OrderDal(Context context, IOrderDetailDal orderDetailService, IProductDal productService, SignInManager<AppUser> signInManager, ICustomerDal customerService, IAppUserDal appUserService)
        {
            _context = context;
            _orderDetailDal = orderDetailService;
            _productDal = productService;
            _signInManager = signInManager;
            _customerDal = customerService;
            _appUserDal = appUserService;
        }

        public Order AddOrderDetailInOrder(OrderDetail orderDetail)
        {
            var orders = _orderDetailDal.GetByDefault(x => x.OrderId == orderDetail.OrderId);
            var detail = orders.FirstOrDefault(x => x.ProductId == orderDetail.ProductId);
            var product = _productDal.GetById(orderDetail.ProductId);

            product.UnıtsInStock -= orderDetail.Quantity;

            var order = GetById(orderDetail.OrderId);

            if (product.UnıtsInStock >= 0)
            {
                if (orders != null)
                {
                    if (detail == null)
                    {
                        orderDetail.UnitPrice = product.UnitPrice;
                        _orderDetailDal.Create(orderDetail);
                        _productDal.Update(product);



                        return order;
                    }
                    else
                    {

                        detail.Quantity += orderDetail.Quantity;

                        _productDal.Update(product);

                        _orderDetailDal.Update(detail);
                        return order;
                    }
                }
                else
                {
                    orderDetail.UnitPrice = product.UnitPrice;
                    _productDal.Update(product);
                    _orderDetailDal.Create(orderDetail);

                    return order;

                }
            }
            else
            {
                order.MasterId = 1;
                product.UnıtsInStock += orderDetail.Quantity;
                return order;
            }


        }

        public void Create(Order entity)
        {

            entity.CreatedBy = _signInManager.Context.User.Identity.Name;
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();


            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public bool CreateOrder(Order order)
        {


            if (order.CustomerId == Guid.Empty)
            {
                var customer = _customerDal.FindByTC(order.Customer.TC);
                if (customer == null)
                {
                    return false;
                }
                order.Customer = customer;
                order.CustomerId = customer.Id;
            }

            if (order.Id == Guid.Empty)
            {
                Create(order);
                order.OrderStatus = EntityLayer.Enum.OrderStatus.Created;
                Update(order);
            }
            else
            {
                var orderList = _orderDetailDal.GetByDefault(x => x.OrderId == order.Id);

            }

            return true;
        }

        public void Delete(Order entity)
        {

            entity.Status = EntityLayer.Enum.Status.Deleted;
            Update(entity);

        }

        public List<Order> GetActive()
        {
            return _context.Orders.Where(x => x.Status == EntityLayer.Enum.Status.Active || x.Status == EntityLayer.Enum.Status.Updated).ToList();
        }

        public List<Order> GetByDefault(Expression<Func<Order, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Orders.Where(filter).ToList();
            }
            else
            {
                return _context.Orders.ToList();
            }
        }

        public Order GetById(Guid id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Order entity)
        {
            entity.UpdatedBy = _signInManager.Context.User.Identity.Name;
            entity.UpdatedComputerName = Environment.MachineName;
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(1).ToString();

            if (entity.Status == EntityLayer.Enum.Status.Deleted)
            {

            }
            else
            {

                entity.Status = EntityLayer.Enum.Status.Updated;
            }

            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
    }
}
