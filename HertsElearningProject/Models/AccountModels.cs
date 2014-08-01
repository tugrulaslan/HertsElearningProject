using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Models
{
    public class AccountModels
    {
    }

    public class EditInfoModel
    {
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
    }

    public class PasswordChangeModel
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 7)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}