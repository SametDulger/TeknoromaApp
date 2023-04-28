using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin,Cashier,MobileSales")]

    public class PremiumController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        public PremiumController(SignInManager<AppUser> signInManager)
        {

            _signInManager = signInManager;
        }

        public ActionResult Index()
        {
            var user = _signInManager.UserManager.FindByNameAsync(User.Identity.Name).Result;

            return View(user);
        }
    }
}
