using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Models
{
    public class PageHits
    {
        [Key]
        public int Id { get; set; }
        public String PageName { get; set; }
        public String Username { get; set; }
        public int Hit { get; set; }
        public String LastVisitStamp { get; set; }
    }
}