using ITB.Business.Entities;
using ITB.Business.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITB.Controllers
{
    [Authorize]
    public class MessageController : BaseController
    {
        MongoSession<Message> session;
        public MessageController()
        {
            session = new MongoSession<Message>();
        }

        // GET: Message
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var fromMe = session.Get(_ => _.FromUserName == User.Identity.Name);
            var toMe = session.Get(_ => _.ToUserName == User.Identity.Name);
            return Json(new { From = fromMe, To = toMe }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Post(Message message) {
            var msg = message;
            msg.FromUserName = User.Identity.Name;
            if (!string.IsNullOrWhiteSpace(msg.Body) && !string.IsNullOrWhiteSpace(msg.ToUserName)) {
                // check if user exists
                msg.ToUserName = msg.ToUserName.Trim();
                msg.Timestamp = DateTime.UtcNow;
                session.Save(msg);
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}