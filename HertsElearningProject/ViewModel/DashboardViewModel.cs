using HertsElearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HertsElearningProject.ViewModel
{
    public class DashboardViewModel
    {
        public List<Users> UsersVM { get; set; }
        public List<PageHits> PageHitsVM { get; set; }
        public List<VisitorStatistics> VisitorStatsVM { get; set; }
        public List<Courses> CoursesVM { get; set; }
        public List<Search> SearchVM { get; set; }
        public List<StudentCourses> StudentCoursesVM { get; set; }
    }
}