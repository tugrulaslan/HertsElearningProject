using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Models
{
    public class VisitorStatistics
    {
        [Key]
        public int Id { get; set; }
        public String UserSession { get; set; }
        public String IPAddress { get; set; }
        public String Country { get; set; }
        public String OperatingSystem { get; set; }
        public String Device { get; set; }
        public String BrowserName { get; set; }
        public String VisitTimeStamp { get; set; }
    }
}