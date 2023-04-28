using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
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
    public class SupplierController : Controller
    {
        private readonly SupplierManager _supplierManager;

        public SupplierController(SupplierManager supplierManager)
        {
           _supplierManager = supplierManager;
        }

        public ActionResult Index()
        {
            return View(_supplierManager.GetActive());
        }

        
        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _supplierManager.Create(supplier);
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
            var update = _supplierManager.GetById(id);
            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _supplierManager.Update(supplier);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        
        public ActionResult Delete(Guid Id)
        {
            try
            {
                var delete = _supplierManager.GetById(Id);
                _supplierManager.Delete(delete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
