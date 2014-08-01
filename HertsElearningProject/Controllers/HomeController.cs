using HertsElearningProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HertsElearningProject.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        PageHitsService pageHitsService = new PageHitsService();
        VisitorStatsService visitorStatsService = new VisitorStatsService();
        String sessionId = System.Web.HttpContext.Current.Session.SessionID;
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                pageHitsService.updatePageHit("Home/Index", User.Identity.Name.ToString());
            }
            else
            {
                //save keep and save visitors stats only for index page
                visitorStatsService.collectVisitorData(Request.Browser.Browser.ToString(), Request.UserHostAddress.ToString(), Request.UserAgent.ToString(), Request.Browser.IsMobileDevice, Request.IsLocal, sessionId);
            }
            return View();
        }
	}
}