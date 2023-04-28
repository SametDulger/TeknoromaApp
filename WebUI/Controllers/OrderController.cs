using BusinessLayer.Abstract;
using BusinessLayer.ApiData;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin,Cashier,MobileSales")]
    public class OrderController : Controller
    {
        private readonly OrderManager _orderManager;
        private readonly OrderDetailManager _orderDetailManager;
        private readonly CustomerManager _customerManager;
        private readonly ProductManager _productManager;
        private readonly AppUserManager _appUserManager;
        private readonly SignInManager<AppUser> _signInManager;

        public OrderController(OrderManager orderManager, OrderDetailManager orderDetailManager, CustomerManager customerManager, ProductManager productManager, AppUserManager appUserManager, SignInManager<AppUser> signInManager)
        {
            _orderManager = orderManager;
            _orderDetailManager = orderDetailManager;
            _customerManager = customerManager;
            _productManager = productManager;
            _appUserManager = appUserManager;
            _signInManager = signInManager;
        }

        public ActionResult Index()
        {
            ViewBag.Created = _orderManager.GetByDefault(x => x.OrderStatus == EntityLayer.Enum.OrderStatus.Created);
            ViewBag.ProductWaiting = _orderManager.GetByDefault(x => x.OrderStatus == EntityLayer.Enum.OrderStatus.ProductWaiting);
            ViewBag.Completed = _orderManager.GetByDefault(x => x.OrderStatus == EntityLayer.Enum.OrderStatus.Completed);
            ViewBag.Customer = _customerManager.GetActive();
            ViewBag.AppUser = _appUserManager.GetByDefault();
            return View();
        }

        public ActionResult CreateOrder()
        {

            ViewBag.Customer = _customerManager.GetActive();
            return View();
        }

        public ActionResult Create(Order order)
        {
            order.AppUser = _signInManager.UserManager.FindByNameAsync(User.Identity.Name).Result;


            if (order.CustomerId == Guid.Empty)
            {
                var customer = _customerManager.FindByTC(order.Customer.TC);
                if (customer == null)
                {
                    return RedirectToAction("CreateOrder");
                }
                order.Customer = customer;
                order.CustomerId = customer.Id;
            }

            if (order.Id == Guid.Empty)
            {
                _orderManager.Create(order);
                order.OrderStatus = EntityLayer.Enum.OrderStatus.Created;
                _orderManager.Update(order);
            }
            else
            {
                var orderList = _orderDetailManager.GetByDefault(x => x.OrderId == order.Id);

                TempData["OrderList"] = orderList;
            }

            EuroDolarXml euroDolar = new EuroDolarXml();

            ViewBag.Euro = euroDolar.Euro;
            ViewBag.Dolar = euroDolar.Dolar;

            var products = _productManager.GetActive();
            var customers = _customerManager.GetById(order.CustomerId);
            ViewBag.Customer = customers;
            ViewBag.Products = products;
            ViewBag.OrderId = order.Id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var order = _orderManager.AddOrderDetailInOrder(orderDetail);
                    var customers = _customerManager.GetById(order.CustomerId);
                    ViewBag.Customer = customers;


                    if (order.MasterId != 1)
                    {
                        return RedirectToAction("Create", order);

                    }
                    else
                    {

                        TempData["Alert"] = "Girilen ürün adedi için yeterli sayıda stok bulunmuyor.";
                        return RedirectToAction("Create", order);
                    }

                }
                catch (Exception)
                {
                    var order = _orderManager.GetById(orderDetail.OrderId);
                    return RedirectToAction("Create", order);
                }
            }
            return View();
        }


        public ActionResult OrderDone(Guid OrderId)
        {
            var order = _orderManager.GetById(OrderId);
            order.Status = EntityLayer.Enum.Status.Active;
            order.OrderStatus = EntityLayer.Enum.OrderStatus.ProductWaiting;
            _orderManager.Update(order);

            return RedirectToAction("Index");
        }


        public ActionResult Detail(Guid id)
        {

            var order = _orderManager.GetById(id);

            var orderList = _orderDetailManager.GetByDefault(x => x.OrderId == order.Id);

            var products = _productManager.GetActive();

            TempData["OrderList"] = orderList;

            EuroDolarXml euroDolar = new EuroDolarXml();

            ViewBag.Euro = euroDolar.Euro;
            ViewBag.Dolar = euroDolar.Dolar;

            var customers = _customerManager.GetById(order.CustomerId);
            ViewBag.Customer = customers;
            ViewBag.Products = products;
            ViewBag.OrderId = order.Id;
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
           if (ModelState.IsValid)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
           return View();
        }


        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
