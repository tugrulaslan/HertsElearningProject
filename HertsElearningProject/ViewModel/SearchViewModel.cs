using HertsElearningProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HertsElearningProject.ViewModel
{
    public class SearchViewModel
    {
        public List<Users> UsersVM { get; set; }
        public List<Courses> CoursesVM { get; set; }
        public Search search { get; set; }
    }
}