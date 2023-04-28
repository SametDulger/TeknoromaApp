using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly AppUserManager _appUserManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public UserController(AppUserManager appUserManager, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _appUserManager = appUserManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            return View(_appUserManager.GetActive());
        }



        public ActionResult Create()
        {
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppUser appUser, string roleName)
        {


            if (ModelState.IsValid)
            {

                var exist = _appUserManager.AddUser(appUser, roleName);

                if (exist.Id != Guid.Empty)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Exist"] = $"{appUser.UserName} Kullanıcısı zaten mevcut";
                    return RedirectToAction("Index");

                }

            }

            return View();

        }

        public ActionResult Edit(Guid id)
        {
            ViewBag.Roles = _roleManager.Roles.ToList();

            var update = _appUserManager.GetById(id);

            return View(update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppUser appUser, string roleName)
        {
           if(ModelState.IsValid)
            {
                try
                {
                    _appUserManager.UpdateUserAndRole(appUser, roleName);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return View();
                }
            }
           return View();
        }


        public ActionResult Delete(AppUser appUser)
        {
            _appUserManager.Delete(appUser);
            return RedirectToAction("Index");
        }

    }
}
