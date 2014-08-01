using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Username field is required")]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 3)]
        public String Username { get; set; }
        [Required(ErrorMessage = "Password field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3)]
        public String Password { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address entered!")]
        [Required(ErrorMessage = "Email field is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required(ErrorMessage = "Name field is required")]
        [Display(Name = "Name")]
        [StringLength(20, MinimumLength = 3)]
        public String Name { get; set; }
        [Required(ErrorMessage = "Lastname field is required")]
        [Display(Name = "Lastname")]
        [StringLength(20, MinimumLength = 3)]
        public String Lastname { get; set; }
        [Display(Name = "Last Login")]
        public String LastLogin { get; set; }
        [Display(Name = "Role ")]
        public String UserRole { get; set; }
    }
}