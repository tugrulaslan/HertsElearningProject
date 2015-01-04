using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Models
{
    [Table("StudentExam")]
    public class StudentExam
    {
        [Key]
        public int Id { get; set; }
        public String StudentName { get; set; }
        public String Question { get; set; }
        public String Answer { get; set; }
        public String StudentAnswer { get; set; }
        public String Correct { get; set; }
    }
}