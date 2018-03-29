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
    public class ClientController : BaseController
    {
        MongoSession<Client> session;
        MongoSession<Project> projSession;
        public ClientController()
        {
            session = new MongoSession<Client>();
            projSession = new MongoSession<Project>();
        }

        public ActionResult Dashboard() {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault() ?? new Client()
            {
                UserName = User.Identity.Name,
                Email = User.Identity.Name
            };

            return View(currentClient);
        }

        // GET: Client
        public ActionResult Index()
        {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault() ?? new Client()
            {
                UserName = User.Identity.Name,
                Email = User.Identity.Name
            };

            return View(currentClient);
        }
        // GET: Client
        public ActionResult Get()
        {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault() ?? new Client()
            {
                UserName = User.Identity.Name,
                Email = User.Identity.Name
            };

            return Json(currentClient, "application/json", JsonRequestBehavior.AllowGet);
        }
        // POST: Client
        public ActionResult Post(Client client)
        {
            session.Save(client);
            return Json(client);
        }

        // PROJECT CRUD
        public ActionResult Project()
        {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();
            var currentProjects = projSession.Get(_ => _.UserName == User.Identity.Name).OrderByDescending(x => x.Id).ToList();

            return View(currentProjects);
        }
        public ActionResult ProjectGet()
        {
            var currentClient = session.Get(_ => _.UserName == User.Identity.Name).SingleOrDefault();
            var currentProjects = projSession.Get(_ => _.UserName == User.Identity.Name).OrderByDescending(x => x.Id).ToList();

            return Json(currentProjects, JsonRequestBehavior.AllowGet);
        }
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
        public ActionResult ProjectDelete(Project project)
        {
            projSession.Delete(project);

            var currentProjects = projSession.Get(_ => _.UserName == User.Identity.Name).OrderByDescending(x => x.Id).ToList();
            return Json(currentProjects, JsonRequestBehavior.AllowGet);
        }
    }
}