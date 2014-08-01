using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Course Name field is required")]
        [Display(Name = "Course Name")]
        [StringLength(20, MinimumLength = 3)]
        public String CourseName { get; set; }
        [Required(ErrorMessage = "Course Credits field is required")]
        [Display(Name = "Course Credits")]
        [Range(1, 30, ErrorMessage = "Course Credits must be between 1-30")]
        public int CourseCredits { get; set; }
        [Display(Name = "Lecturer Name")]
        public String LecturerName { get; set; }
        [Display(Name = "Lecturer Lastname")]
        public String LecturerLastname { get; set; }
        [Required(ErrorMessage = "Lecturer Id field is required")]
        [Display(Name = "Lecturer Id")]
        public int LecturerId { get; set; }
    }
}