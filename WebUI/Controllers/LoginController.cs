using BusinessLayer.Concrete;
using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;
using WebUI.ViewModels;

namespace WebUI.Controllers
{

    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppUserManager _appUserManager;
        private readonly Context _context;

        public LoginController(Context context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppUserManager appUserManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUserManager = appUserManager;
            _context = context;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM loginVM)
        {
            var user = _userManager.FindByNameAsync(loginVM.UserName).Result;



            if (user != null)
            {
                var result = _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsPersistent, false).Result;
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");

                }

                return RedirectToAction("Login", "Login");
            }

            return RedirectToAction("Login", "Login");

        }


        public async Task<IActionResult> LogOut(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Login");


        }

    }
}
