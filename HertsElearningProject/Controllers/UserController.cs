using HertsElearningProject.Models;
using HertsElearningProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HertsElearningProject.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        HertsOnlineEntities db = new HertsOnlineEntities();
        PageHitsService pageHits = new PageHitsService();
        public ActionResult Index()
        {
            Users users = db.UserEntity.Where(x => x.Username == User.Identity.Name).First();
            pageHits.updatePageHit("Users/Index", User.Identity.Name);
            return View(users);
        }
	}
}