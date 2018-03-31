using ITB.Business;
using ITB.Business.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ITB.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
        MongoSession<Client> session;
        MongoSession<Project> projSession;
        public ClientController()
        {
            session = new MongoSession<Client>();
            projSession = new MongoSession<Project>();
        }

        [Authorize(Roles = "client")]
        public ActionResult Dashboard() {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();

            return View(currentClient);
        }

        // GET: Client
        [Authorize(Roles = "client")]
        public ActionResult Index()
        {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();

            return View(currentClient);
        }
        // GET: Client
        [Authorize(Roles = "client")]
        public ActionResult Get()
        {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();

            return Json(currentClient, "application/json", JsonRequestBehavior.AllowGet);
        }
        // POST: Client
        [Authorize(Roles = "client")]
        public ActionResult Post(Client client)
        {
            session.Save(client);
            return Json(client);
        }

        // PROJECT CRUD
        [Authorize(Roles = "client")]
        public ActionResult Project()
        {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();
            var currentProjects = projSession.Get(_ => _.UserName == User.Identity.Name).OrderByDescending(x => x.Id).ToList();

            return View(currentProjects);
        }
        [Authorize(Roles = "client")]
        public ActionResult ProjectGet()
        {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();
            var currentProjects = projSession.Get(_ => _.UserName == User.Identity.Name).OrderByDescending(x => x.Id).ToList();

            return Json(currentProjects, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "client,contractor")]
        public ActionResult ProjectSearch()
        {
            var currentProjects = projSession.Get(_ => true).OrderByDescending(x => x.Id).ToList();

            return Json(currentProjects, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "client")]
        public ActionResult ProjectPost(Project project)
        {
            if (project.Id == null) {
                project.UserName = User.Identity.Name;
                project.Timestamp = DateTime.UtcNow;
            }
            projSession.Save(project);

            var currentProjects = projSession.Get(_ => _.UserName == User.Identity.Name).OrderByDescending(x => x.Id).ToList();
            return Json(currentProjects, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "client")]
        public ActionResult ProjectDelete(Project project)
        {
            projSession.Delete(project);

            var currentProjects = projSession.Get(_ => _.UserName == User.Identity.Name).OrderByDescending(x => x.Id).ToList();
            return Json(currentProjects, JsonRequestBehavior.AllowGet);
        }
    }
}