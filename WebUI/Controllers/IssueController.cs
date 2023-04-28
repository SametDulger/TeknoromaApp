using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin,Accounting,Cashier,MobileSales,StockRoom")]
    public class IssueController : Controller
    {
        private readonly IssueManager _issueManager;
        private readonly AppUserManager _appUserManager;

        public IssueController(IssueManager issueManager, AppUserManager appUserManager)
        {
            _issueManager = issueManager;
            _appUserManager = appUserManager;
        }

        public ActionResult Index()
        {
            ViewBag.User = _appUserManager.GetActive();
            ViewBag.OpenIssue = _issueManager.GetByDefault(x => x.IssueStatus == EntityLayer.Enum.IssueStatus.Open);
            ViewBag.CheckingIssue = _issueManager.GetByDefault(x => x.IssueStatus == EntityLayer.Enum.IssueStatus.Checking);
            ViewBag.ClosedIssue = _issueManager.GetByDefault(x => x.IssueStatus == EntityLayer.Enum.IssueStatus.Closed);
            return View();
        }


        public ActionResult Create()
        {
            ViewBag.AppUser = _appUserManager.GetActive();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Issue issue)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    issue.IssueStatus = EntityLayer.Enum.IssueStatus.Open;
                    _issueManager.Create(issue);
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
            ViewBag.AppUser = _appUserManager.GetActive();
            var issue = _issueManager.GetById(id);
            return View(issue);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Issue issue)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _issueManager.Update(issue);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Detail(Guid id)
        {
            var issue = _issueManager.GetById(id);
            return View(issue);
        }

        public ActionResult ClosedDetail(Guid id)
        {
            ViewBag.AppUser = _appUserManager.GetActive();
            var issue = _issueManager.GetById(id);
            return View(issue);
        }

        public ActionResult Delete(Guid id)
        {
            var issue = _issueManager.GetById(id);
            _issueManager.Delete(issue);
            return RedirectToAction(nameof(Index));
        }


    }
}
