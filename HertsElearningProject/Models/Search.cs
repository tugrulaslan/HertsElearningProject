using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Models
{
    [Table("Search")]
    public class Search
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Course Name field is required")]
        [Display(Name = "Keyword")]
        [StringLength(20, MinimumLength = 3)]
        public String Keyword { get; set; }
        public int Hit { get; set; }
        public String SearchTimeStamp { get; set; }
    }
}