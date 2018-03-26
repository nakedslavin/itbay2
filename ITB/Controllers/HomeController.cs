using ITB.Business;
using ITB.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITB.Controllers
{
    public class HomeController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            
            if (User.IsInRole(EntityRole.Contractor.ToString().ToLower()))
                return RedirectToAction(nameof(Index), EntityRole.Contractor.ToString());
            return RedirectToAction(nameof(Index), EntityRole.Client.ToString());
        }

        public ActionResult Dashboard() {
            if (User.IsInRole(EntityRole.Contractor.ToString().ToLower()))
                return RedirectToAction(nameof(Dashboard), EntityRole.Contractor.ToString());
            return RedirectToAction(nameof(Dashboard), EntityRole.Client.ToString());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}