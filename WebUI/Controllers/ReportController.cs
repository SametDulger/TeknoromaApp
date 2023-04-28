using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ReportController : Controller
    {
        private readonly SupplierExpenseManager _supplierExpenseManager;
        private readonly ProductManager _productManager;
        private readonly SupplierManager _supplierManager;
        private readonly AppUserManager _appUserManager;
        private readonly OrderDetailManager _orderDetailManager;
        private readonly ExpenseManager _expenseManager;
        private readonly EmployeePaymentManager _employeePaymentManager;
        private readonly CategoryManager _categoryManager;
        private readonly SubCategoryManager _subCategoryManager;

        public ReportController(SupplierExpenseManager supplierExpenseManager,ProductManager productManager, SupplierManager supplierManager,AppUserManager appUserManager,OrderDetailManager orderDetailManager,ExpenseManager expenseManager,EmployeePaymentManager employeePaymentManager,CategoryManager categoryManager,SubCategoryManager subCategoryManager)
        {
            _supplierExpenseManager = supplierExpenseManager;
            _productManager = productManager;
            _supplierManager = supplierManager;
            _appUserManager = appUserManager;
            _orderDetailManager = orderDetailManager;
            _expenseManager = expenseManager;
            _employeePaymentManager = employeePaymentManager;
            _categoryManager = categoryManager;
            _subCategoryManager = subCategoryManager;
        }


        public IActionResult SupplierReport()
        {
            var allTimeReport = _supplierExpenseManager.GetAllTimeReport();
            var mountlyReport = _supplierExpenseManager.GetMonthlyReport();

            ViewBag.AllTime = allTimeReport;
            ViewBag.Mountly = mountlyReport;

            return View();
        }

        public IActionResult ProductReport()
        {
            try
            {
                var products = _productManager.GetByDefault(x => x.Status == EntityLayer.Enum.Status.Deleted);
                ViewBag.Product = products;

                var top10 = _productManager.GetTop10();


                return View(top10);
            }
            catch (Exception)
            {
                TempData["Error"] = "Upss.. Bir hata meydana  geldi.";
                return View();
            }

        }

        public IActionResult ProductBuyers(Guid productId)
        {
            try
            {
                var top10 = _productManager.GetTop10().Where(x => x.ProductId == productId);
                if (top10.Count() > 0)
                {
                    List<Customer> customers = new List<Customer>();
                    foreach (var item in top10)
                    {
                        foreach (var customer in item.Customers)
                        {
                            customers.Add(customer);
                        }
                    }

                    return View(customers);
                }

                TempData["Error"] = "Ürün Id'ye ulaşılamıyor lütfen tekrar deneyin";
                return View();
            }
            catch (Exception)
            {

                TempData["Error"] = "Upss.. Bir hata meydana  geldi.";
                return View();
            }

        }

        public IActionResult CategoryReport()
        {
            ViewBag.SubCategory = _subCategoryManager.GetActive();
            return View(_categoryManager.GetActive());
        }

        public IActionResult ProductList(Guid id)
        {
            var productList = _productManager.GetByDefault(x => x.SubCategoryId == id);
            ViewBag.Suppliers = _supplierManager.GetActive();
            ViewBag.subCategories = _subCategoryManager.GetActive();

            return View(productList);
        }

        public IActionResult ExpenseReport()
        {
            ViewBag.Expense = _expenseManager.GetActive();
            ViewBag.EmployeePayment = _employeePaymentManager.GetActive();
            ViewBag.AppUser = _appUserManager.GetActive();

            return View();
        }

        public IActionResult SalesTrackingReport()
        {
            var users = _appUserManager.GetActive();
           
            return View(users);
        }

    }
}
