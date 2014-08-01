using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Models
{
    public class StudentCourses
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username field is required")]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 3)]
        public String Username { get; set; }
        [Required(ErrorMessage = "Course Id field is required")]
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public String CourseName { get; set; }
        [Display(Name = "Course Credits")]
        public int CourseCredits { get; set; }
        [Required(ErrorMessage = "Lecturer Id field is required")]
        [Display(Name = "Lecturer Id")]
        public int LecturerId { get; set; }
        [Display(Name = "Lecturer Name")]
        public String LecturerName { get; set; }
        [Display(Name = "Lecturer Lastname")]
        public String LecturerLastname { get; set; }
    }
}