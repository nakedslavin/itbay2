using ITB.Business;
using ITB.Business.Repos;
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
    public class ServiceController : BaseController
    {
        Repo repo;
        public ServiceController()
        {
            repo = new Repo();
        }

        [Authorize]
        public ActionResult Locations()
        {
            var locations = repo.Locations.Select(l => l.city);
            return Json(locations, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult Positions()
        {
            return Json(repo.Positions, JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult Skills()
        {
            return Json(repo.Skills, JsonRequestBehavior.AllowGet);
        }
    }
}