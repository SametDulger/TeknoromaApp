using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin,StockRoom")]
    public class SalesController : Controller
    {
        private readonly OrderManager _orderManager;
        private readonly AppUserManager _appUserManager;
        private readonly CustomerManager _customerManager;
        private readonly ProductManager _productManager;
        private readonly OrderDetailManager _orderDetailManager;

        public SalesController(OrderManager orderManager, AppUserManager appUserManager, CustomerManager customerManager, ProductManager productManager, OrderDetailManager orderDetailManager)
        {
            _orderManager = orderManager;
            _appUserManager = appUserManager;
            _customerManager = customerManager;
            _productManager = productManager;
            _orderDetailManager = orderDetailManager;
        }

        public ActionResult Index()
        {
            ViewBag.Customer = _customerManager.GetActive();
            ViewBag.AppUser = _appUserManager.GetByDefault();

            var productWaiting = _orderManager.GetByDefault(x => x.OrderStatus == EntityLayer.Enum.OrderStatus.ProductWaiting);
            return View(productWaiting);
        }


        public ActionResult OrderDetail(Guid id)
        {
            var order = _orderManager.GetById(id);
            var orderDetail = _orderDetailManager.GetByDefault(x => x.OrderId == order.Id);
            ViewBag.OrderId = order.Id;
            ViewBag.Product = _productManager.GetActive();
            var user = _appUserManager.GetByDefault(x => x.Id == order.AppUserId);
            ViewBag.User = user;

            return View(orderDetail);
        }


        public ActionResult ProductDelivered(Guid id)
        {
            var order = _orderManager.GetById(id);
            order.OrderStatus = EntityLayer.Enum.OrderStatus.Completed;
            order.Status = EntityLayer.Enum.Status.Active;
            _orderManager.Update(order);

            return RedirectToAction("Index");
        }
    }
}
