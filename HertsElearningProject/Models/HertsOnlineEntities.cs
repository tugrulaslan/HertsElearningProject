using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Models
{
    public class HertsOnlineEntities : DbContext
    {
        public DbSet<Users> UserEntity { get; set; }
        public DbSet<VisitorStatistics> VisitorStatisticsEntity { get; set; }
        public DbSet<PageHits> PageHitsEntity { get; set; }
        public DbSet<Courses> CoursesEntity { get; set; }
        public DbSet<Search> SearchEntity { get; set; }
        public DbSet<StudentCourses> StudentCourseEntity { get; set; }
    }
}