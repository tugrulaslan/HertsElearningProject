using HertsElearningProject.Models;
using HertsElearningProject.Service;
using HertsElearningProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HertsElearningProject.Controllers
{
    public class SearchController : Controller
    {
        private HertsOnlineEntities db = new HertsOnlineEntities();
        PageHitsService pageHits = new PageHitsService();
        SearchService searchService = new SearchService();
        // GET: /Search/
        public ActionResult Index()
        {
            pageHits.updatePageHit("Search/Index", User.Identity.Name.ToString());
            return View();
        }
        [HttpPost]
        public ActionResult Index(Search model)
        {

            searchService.updateSearchHit(model.Keyword);
            var keyword = model.Keyword;
            return RedirectToAction("SearchResult", "Search", model);
        }

        public ActionResult SearchResult(Search model)
        {
            pageHits.updatePageHit("Search/SearchResult", User.Identity.Name);
            SearchViewModel vm = new SearchViewModel();
            List<Users> UserVM = db.UserEntity.Where(x => x.Name.Contains(model.Keyword) || x.Lastname.Contains(model.Keyword) || x.Email.Contains(model.Keyword) || x.UserRole.Contains(model.Keyword)).ToList();
            List<Courses> CourseVM = db.CoursesEntity.Where(x => x.CourseName.Contains(model.Keyword) || x.LecturerName.Contains(model.Keyword) || x.LecturerLastname.Contains(model.Keyword)).ToList();

            vm.UsersVM = UserVM;
            vm.CoursesVM = CourseVM;
            vm.search = model;
            return View(vm);
        }
    }
}