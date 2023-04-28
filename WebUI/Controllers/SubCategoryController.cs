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
    [Authorize(Roles = "Admin")]
    public class SubCategoryController : Controller
    {
        private readonly SubCategoryManager _subCategoryManager;
        private readonly CategoryManager _categoryManager;

        public SubCategoryController(SubCategoryManager subCategoryManager,CategoryManager categoryManager)
        {
           _subCategoryManager = subCategoryManager;
           _categoryManager = categoryManager;
        }

        public ActionResult Index()
        {
            ViewBag.Categories = _categoryManager.GetActive();
            return View(_subCategoryManager.GetActive());
        }


        public ActionResult Create()
        {
            ViewBag.Categories = _categoryManager.GetActive();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _subCategoryManager.Create(subCategory);
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
            ViewBag.Categories = _categoryManager.GetActive();
            var update = _subCategoryManager.GetById(id);
            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategory subCategory)
        {
           if (ModelState.IsValid)
            {
                try
                {
                    _subCategoryManager.Update(subCategory);
                    return RedirectToAction(nameof(Index));
                }
                catch
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
                var delete = _subCategoryManager.GetById(id);
                _subCategoryManager.Delete(delete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
