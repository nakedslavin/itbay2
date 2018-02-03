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
    public class ContractorController : BaseController
    {
        MongoSession<Contractor> session;
        public ContractorController()
        {
            session = new MongoSession<Contractor>();
        }
        // GET: Contractor
        public ActionResult Index()
        {
            var currentContractor = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault() ?? new Contractor() {
                UserName = User.Identity.Name,
                Email = User.Identity.Name
            };
            //currentContractor.SelectedCities.Add("Vladimir");
            //if (currentUser == null) {
            //    var user = await UserManager.FindByNameAsync(User.Identity.Name);
                
            //}
            

            return View(currentContractor);
        }

        // GET: Contractor
        public ActionResult Get()
        {
            var currentContractor = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault() ?? 
            new Contractor()
            {
                UserName = User.Identity.Name,
                Email = User.Identity.Name
            };
            //currentContractor.SelectedCities.Add("Vladimir");
            return Json(currentContractor, "application/json", JsonRequestBehavior.AllowGet);
        }
        // POST: Contractor
        public ActionResult Post(Contractor contractor)
        {
            session.Save(contractor);
            return Json(contractor);
        }
    }
}