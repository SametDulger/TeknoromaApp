using BusinessLayer.Abstract;
using BusinessLayer.ApiData;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebUI.Controllers
{

    [Authorize(Roles = "Admin,Accounting")]

    public class ExpenseController : Controller
    {
        private readonly ExpenseManager _expenseManager;
        private readonly AppUserManager _appUserManager;
        private readonly EmployeePaymentManager _employeePaymentManager;

        public ExpenseController(ExpenseManager expenseManager, AppUserManager appUserManager, EmployeePaymentManager employeePaymentManager)
        {
            _expenseManager = expenseManager;
            _appUserManager = appUserManager;
            _employeePaymentManager = employeePaymentManager;
        }

        public ActionResult Index()
        {
            ViewBag.AppUser = _appUserManager.GetActive();
            ViewBag.EmployeePayment = _employeePaymentManager.GetActive();
            ViewBag.Expense = _expenseManager.GetActive();
            return View();
        }

        public ActionResult SelectMonth()
        {
            return View();
        }

        public ActionResult Sales(DateTime time)
        {
            var salesList = _expenseManager.MonthlySales(time);
            return View(salesList);
        }


        public ActionResult Create()
        {
            EuroDolarXml doviz = new EuroDolarXml();
            ViewBag.Dolar = doviz.Dolar;
            ViewBag.Euro = doviz.Euro;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _expenseManager.Create(expense);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();

        }


        public ActionResult CreateEmployeePayment()
        {
            EuroDolarXml doviz = new EuroDolarXml();
            ViewBag.Dolar = doviz.Dolar;
            ViewBag.Euro = doviz.Euro;
            ViewBag.AppUser = _appUserManager.GetActive();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployeePayment(EmployeePayment employeePayment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeePaymentManager.Create(employeePayment);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }


        public ActionResult Edit(Guid id)
        {
            var exp = _expenseManager.GetById(id);
            return View(exp);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _expenseManager.Update(expense);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult EditEmployeePayment(Guid id)
        {
            ViewBag.AppUser = _appUserManager.GetActive();
            var empPayment = _employeePaymentManager.GetById(id);
            return View(empPayment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployeePayment(EmployeePayment employeePayment)
        {
           if (ModelState.IsValid)
            {
                try
                {
                    _employeePaymentManager.Update(employeePayment);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
           return View();
        }


        public ActionResult DeleteEmployeePayment(Guid id)
        {
            var deleteEmpPayment = _employeePaymentManager.GetById(id);
            _employeePaymentManager.Delete(deleteEmpPayment);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(Guid id)
        {
            var deleted = _expenseManager.GetById(id);
            _expenseManager.Delete(deleted);
            return RedirectToAction(nameof(Index));
        }

    }
}
