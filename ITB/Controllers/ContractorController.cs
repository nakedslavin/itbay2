using ITB.Business;
using ITB.Business.Repos;
using ITB.Business.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ITB.Controllers
{
    [Authorize]
    public class ContractorController : BaseController
    {
        MongoSession<Contractor> session;
        public ContractorController()
        {
            session = new MongoSession<Contractor>();
        }

        [Authorize(Roles = "contractor")]
        public ActionResult Dashboard()
        {
            var currentContractor = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();

            return View(currentContractor);
        }

        // GET: Contractor
        [Authorize(Roles = "contractor")]
        public ActionResult Index()
        {
            var currentContractor = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();
            
            return View(currentContractor);
        }

        // GET: Contractor
        [Authorize(Roles = "contractor")]
        public ActionResult Get()
        {
            var currentContractor = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();
            return Json(currentContractor, "application/json", JsonRequestBehavior.AllowGet);
        }
        // POST: Contractor
        [Authorize(Roles = "contractor")]
        public ActionResult Post(Contractor contractor)
        {
            session.Save(contractor);
            return Json(contractor);
        }

        // GET: Contractors
        [Authorize(Roles ="contractor,client")]
        public ActionResult Search() {
            var contractors = session.Get(_ => true);
            return Json(contractors, JsonRequestBehavior.AllowGet);
        }
    }
}