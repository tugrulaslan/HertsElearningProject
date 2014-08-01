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
    public class DashboardController : Controller
    {
        //
        HertsOnlineEntities db = new HertsOnlineEntities();
        PageHitsService pageHits = new PageHitsService();
        //
        // GET: /Dashboard/
        [Authorize(Roles = "Lecturer")]
        public ActionResult Index()
        {
            DashboardViewModel vm = new DashboardViewModel();
            List<Users> userVM = db.UserEntity.OrderBy(o => o.Id).ToList();
            List<PageHits> pageHitsVM = db.PageHitsEntity.OrderByDescending(o => o.Hit).ToList();
            List<VisitorStatistics> visitorStatsVM = db.VisitorStatisticsEntity.OrderBy(o => o.Id).ToList();
            List<Courses> coursesVM = db.CoursesEntity.OrderBy(o => o.Id).ToList();
            List<Search> searchVM = db.SearchEntity.OrderByDescending(o => o.Hit).ToList();
            List<StudentCourses> studentCoursesVM = db.StudentCourseEntity.OrderBy(o => o.Id).ToList();

            //counts
            ViewBag.totalUserCount = db.UserEntity.Count();

            ViewBag.totalStudents = db.UserEntity.Where(u => u.UserRole == "Student").Count();

            ViewBag.totalLecturers = db.UserEntity.Where(u => u.UserRole == "Lecturer").Count();

            ViewBag.totalPageHits = db.PageHitsEntity.Count();

            PageHits mostViewedPage = db.PageHitsEntity.OrderByDescending(u => u.Hit).FirstOrDefault();

            ViewBag.mostViewedPageHit = mostViewedPage.Hit;
            ViewBag.mostViewedPage = mostViewedPage.PageName;
            ViewBag.mostViewedVisitDate = mostViewedPage.LastVisitStamp;
            ViewBag.totalVisitData = db.PageHitsEntity.Count();


            //Visitor stats data
            List<VisitorStatistics> visitorData = db.VisitorStatisticsEntity.ToList();

            //Lists
            //List<String> countryData = new List<string>();
            List<String> countryDataTemp = new List<string>();
            //List<String> osData = new List<string>();
            List<String> osDataTemp = new List<string>();
            //List<String> deviceData = new List<string>();
            List<String> deviceDataTemp = new List<string>();
            //List<String> browserData = new List<string>();
            List<String> browserDataTemp = new List<string>();

            //Filling all lists with datadas
            for (int i = 0; i < visitorData.Count; i++)
            {
                countryDataTemp.Add(visitorData.ElementAt(i).Country.ToString());
                osDataTemp.Add(visitorData.ElementAt(i).OperatingSystem.ToString());
                deviceDataTemp.Add(visitorData.ElementAt(i).Device.ToString());
                browserDataTemp.Add(visitorData.ElementAt(i).BrowserName.ToString());
            }

            List<String> countryData = countryDataTemp.Distinct().ToList<String>();
            List<String> osData = osDataTemp.Distinct().ToList<String>();
            List<String> deviceData = deviceDataTemp.Distinct().ToList<String>();
            List<String> browserData = browserDataTemp.Distinct().ToList<String>();
            countryData.Remove("localhost");

            ViewBag.totalCountry = countryData.Count;
            ViewBag.totalOS = osData.Count;
            ViewBag.totalDevice = deviceData.Count;
            ViewBag.totalBrowser = browserData.Count;

            ViewBag.Country = countryData;
            ViewBag.OS = osData;
            ViewBag.Device = deviceData;
            ViewBag.Browser = browserData;


            //course info
            List<Courses> courseData = db.CoursesEntity.ToList();
            List<String> lecturerDataTemp = new List<String>();
            ViewBag.totalCourses = db.CoursesEntity.Count();
            int totalCredits = 0;
            for (int i = 0; i < courseData.Count; i++)
            {
                totalCredits += courseData.ElementAt(i).CourseCredits;
                lecturerDataTemp.Add(courseData.ElementAt(i).LecturerName);
            }
            List<String> lecturerData = lecturerDataTemp.Distinct().ToList<String>();

            //enrolled courses
            List<StudentCourses> studentCourseData = db.StudentCourseEntity.ToList();
            List<String> studentCourseTemp = new List<String>();
            int enrolledCourseAmount = 0;
            int enrolledAchievedCredits = 0;
            for (int i = 0; i < studentCourseData.Count; i++)
            {
                studentCourseTemp.Add(studentCourseData.ElementAt(i).Username);
                enrolledCourseAmount++;
                enrolledAchievedCredits += studentCourseData.ElementAt(i).CourseCredits;
            }
            List<String> studentCourse = studentCourseTemp.Distinct().ToList<String>();
            ViewBag.studentCount = studentCourse.Count;
            ViewBag.enrolledCourseAmount = enrolledCourseAmount;
            ViewBag.enrolledAchievedCredits = enrolledAchievedCredits;

            //search stats
            Search search = db.SearchEntity.OrderByDescending(o => o.Hit).First();
            ViewBag.mostSearchedKeyword = search.Keyword;
            ViewBag.mostSearchedKeywordHit = search.Hit;
            ViewBag.amountSearchKeyword = db.SearchEntity.Count();


            ViewBag.totalCredits = totalCredits;
            ViewBag.totalLecturers = lecturerData.Count;
            vm.UsersVM = userVM;
            vm.PageHitsVM = pageHitsVM;
            vm.VisitorStatsVM = visitorStatsVM;
            vm.CoursesVM = coursesVM;
            vm.SearchVM = searchVM;
            vm.StudentCoursesVM = studentCoursesVM;

            pageHits.updatePageHit("Dashboard/Index", User.Identity.Name);

            return View(vm);
        }

        [Authorize(Roles = "Student")]
        public ActionResult StudentIndex()
        {
            DashboardViewModel vm = new DashboardViewModel();
            List<Users> userVM = db.UserEntity.Where(x => x.Username == User.Identity.Name).ToList();
            List<PageHits> pageHitsVM = db.PageHitsEntity.Where(y => y.Username == User.Identity.Name).OrderByDescending(o => o.Hit).ToList();
            List<StudentCourses> studentCourseVM = db.StudentCourseEntity.Where(s => s.Username == User.Identity.Name).OrderByDescending(o => o.Id).ToList();

            vm.UsersVM = userVM;
            vm.PageHitsVM = pageHitsVM;
            vm.StudentCoursesVM = studentCourseVM;

            pageHits.updatePageHit("Dashboard/StudentIndex", User.Identity.Name);

            return View(vm);
        }
	}
}