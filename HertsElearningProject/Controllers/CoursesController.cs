using HertsElearningProject.Models;
using HertsElearningProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HertsElearningProject.Controllers
{
    public class CoursesController : Controller
    {
        private HertsOnlineEntities db = new HertsOnlineEntities();
        PageHitsService pageHits = new PageHitsService();

        [Authorize(Roles = "Lecturer")]
        // GET: /Courses/
        public ActionResult Index()
        {
            List<Courses> courses = db.CoursesEntity.ToList();
            pageHits.updatePageHit("Courses/Index", User.Identity.Name);
            return View(courses);
        }

        [Authorize(Roles = "Lecturer")]
        // GET: /Courses/Create
        public ActionResult Create()
        {
            ViewBag.LecturerId = new SelectList(db.UserEntity.Where(x => x.UserRole == "Lecturer"), "Id", "Name");
            pageHits.updatePageHit("Courses/Create", User.Identity.Name);
            return View();
        }

        // POST: /Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,CourseName,Coursecredits,LecturerId")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                Users user = db.UserEntity.Where(x => x.Id == courses.LecturerId).FirstOrDefault();
                Courses newCourse = new Courses();
                newCourse.CourseName = courses.CourseName;
                newCourse.CourseCredits = courses.CourseCredits;
                newCourse.LecturerName = user.Name;
                newCourse.LecturerLastname = user.Lastname;
                newCourse.LecturerId = courses.LecturerId;

                db.CoursesEntity.Add(newCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courses);
        }
        [Authorize(Roles = "Lecturer")]
        public ActionResult Delete(int? id)
        {
            Courses courses = db.CoursesEntity.Find(id);
            db.CoursesEntity.Remove(courses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Student")]
        public ActionResult StudentIndex()
        {
            List<Courses> courses = db.CoursesEntity.ToList();
            List<StudentCourses> registeredCourses = db.StudentCourseEntity.Where(x => x.Username == User.Identity.Name).ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 0; i < courses.Count; i++)
            {
                items.Add(new SelectListItem { Text = courses.ElementAt(i).CourseName, Value = courses.ElementAt(i).Id.ToString() });
            }
           
            ViewBag.Courses = items;
            pageHits.updatePageHit("Courses/StudentIndex", User.Identity.Name);
            return View(registeredCourses);
        }

        [HttpPost]
        public ActionResult StudentIndex(String Courses)
        {
            int courseID = Int32.Parse(Courses);

            Courses course = db.CoursesEntity.Find(courseID);
            StudentCourses student = new StudentCourses();

            student.Username = User.Identity.Name;
            student.CourseId = courseID;
            student.CourseName = course.CourseName;
            student.CourseCredits = course.CourseCredits;
            student.LecturerId = course.LecturerId;
            student.LecturerName = course.LecturerName;
            student.LecturerLastname = course.LecturerLastname;

            db.StudentCourseEntity.Add(student);
            db.SaveChanges();
            return RedirectToAction("StudentIndex");
        }


        [Authorize(Roles = "Student")]
        public ActionResult DeleteStudentCourse(int? id)
        {
            StudentCourses student = db.StudentCourseEntity.Find(id);
            db.StudentCourseEntity.Remove(student);
            db.SaveChanges();
            return RedirectToAction("StudentIndex");
        }
        [Authorize(Roles = "Student")]
        public ActionResult RegisterNewCourse()
        {
            List<Courses> courses = db.CoursesEntity.ToList();
            List<StudentCourses> registeredCourses = db.StudentCourseEntity.Where(x => x.Username == User.Identity.Name).ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            int count = 0;
            //Check taken courses!

            for (int i = 0; i < courses.Count; i++)
            {
                items.Add(new SelectListItem { Text = courses.ElementAt(i).CourseName, Value = courses.ElementAt(i).Id.ToString() });
            }

            ViewBag.Courses = items;

            return View();
        }

    }
}