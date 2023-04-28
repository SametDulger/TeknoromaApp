using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly SubCategoryManager _subCategoryManager;

        public CategoryController(CategoryManager categoryManager, SubCategoryManager subCategoryManager)
        {
            _categoryManager = categoryManager;
            _subCategoryManager = subCategoryManager;
        }

        public ActionResult Index()
        {
            ViewBag.subCategory = _subCategoryManager.GetActive();
            return View(_categoryManager.GetActive());
        }



        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Create(category);
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Edit(Guid id)
        {
            var update = _categoryManager.GetById(id);
            return View(update);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryManager.Update(category);

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
                var delete = _categoryManager.GetById(id);
                _categoryManager.Delete(delete);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
