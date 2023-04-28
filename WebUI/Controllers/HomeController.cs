using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
	[Authorize(Roles = "Admin,Accounting,Cashier,MobileSales,StockRoom,TechnicalService")]

	public class HomeController : Controller
    {
                    
        public IActionResult Index()
        {
            return View();
        }

    }
}
