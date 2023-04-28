using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin,StockRoom")]
    public class ProductController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly SubCategoryManager _subCategoryManager;
        private readonly SupplierManager _supplierManager;
        private readonly SupplierExpenseManager _supplierExpenseManager;
		private readonly IWebHostEnvironment _webHostEnvironment;


		public ProductController(ProductManager productManager,SubCategoryManager subCategoryManager,SupplierManager supplierManager,SupplierExpenseManager supplierExpenseManager, IWebHostEnvironment webHostEnvironment)
        {
            _productManager = productManager;
            _subCategoryManager = subCategoryManager;
            _supplierManager = supplierManager;
            _supplierExpenseManager = supplierExpenseManager;
			_webHostEnvironment = webHostEnvironment;

		}

        public ActionResult Index()
        {
            ViewBag.subCategories = _subCategoryManager.GetActive();
            ViewBag.suppliers = _supplierManager.GetActive();
            return View(_productManager.GetActive());
        }


        public ActionResult Create()
        {
            ViewBag.subCategories = _subCategoryManager.GetActive();
            ViewBag.suppliers = _supplierManager.GetActive();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   if(product.ImageFile != null)
                    {
                        var extension = Path.GetExtension(product.ImageFile.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/", newImageName);
                        var stream = new FileStream(location, FileMode.Create);
                        product.ImageFile.CopyTo(stream);
                        product.ImageName = newImageName;

                    }
                  
                    _productManager.Create(product);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return View();
                }
            }
            return View();
        }

        
        public ActionResult Edit(Guid id)
        {
            ViewBag.subCategories = _subCategoryManager.GetActive();
            
            var update = _productManager.GetById(id);
            return View(update);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ImageFile != null)
                    {
                        var extension = Path.GetExtension(product.ImageFile.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/", newImageName);
                        var stream = new FileStream(location, FileMode.Create);
                        product.ImageFile.CopyTo(stream);
                        product.ImageName = newImageName;

                    }

                    _productManager.Update(product);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return View();
                }
            }
            return View();
        }

        
        public ActionResult Delete(Guid id)
        {
            try
            {
                var delete = _productManager.GetById(id);
                _productManager.Delete(delete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult AddStock(Guid id)
        {
            var product = _productManager.GetById(id);
            var supplier = _supplierManager.GetById(product.SupplierId);
            ViewBag.Supplier = supplier;
            ViewBag.Product = product;
            return View();
        }

        [HttpPost]
        public IActionResult AddStock(SupplierExpense supplierExpense)
        {
           if(ModelState.IsValid)
            {
                try
                {
                    _supplierExpenseManager.Create(supplierExpense);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    throw;
                }
            }
           return View();
        }
    }
}
