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
    [Authorize(Roles = "Admin,TechnicalService")]
    public class SupportController : Controller
    {
        private readonly IssueManager _issueManager;
        private readonly AppUserManager _appUserManager;

        public SupportController(IssueManager issueManager,AppUserManager appUserManager)
        {
            _issueManager = issueManager;
            _appUserManager = appUserManager;
        }

        public ActionResult Index()
        {
            ViewBag.AppUser = _appUserManager.GetActive();
            ViewBag.OpenIssue = _issueManager.GetByDefault(x => x.IssueStatus == EntityLayer.Enum.IssueStatus.Open);
            ViewBag.CheckingIssue = _issueManager.GetByDefault(x => x.IssueStatus == EntityLayer.Enum.IssueStatus.Checking);
            ViewBag.ClosedIssue = _issueManager.GetByDefault(x => x.IssueStatus == EntityLayer.Enum.IssueStatus.Closed);
            return View();
        }

        
        public ActionResult Details(Guid id)
        {
            var issue = _issueManager.GetById(id);

            return View(issue);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        
        public ActionResult UpdateStatus(Guid id)
        {
            var issue = _issueManager.GetById(id);
            issue.IssueStatus = EntityLayer.Enum.IssueStatus.Checking;
            _issueManager.Update(issue);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult ClosedDetails(Guid id)
        {
            ViewBag.AppUser = _appUserManager.GetActive();
            var issue = _issueManager.GetById(id);
            return View(issue);
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
                    issue.IssueStatus = EntityLayer.Enum.IssueStatus.Closed;
                    _issueManager.Update(issue);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return View();
                }
            }
            return View();
        }

        
        public ActionResult Delete(int id)
        {
            return View();
        }

        
    }
}
