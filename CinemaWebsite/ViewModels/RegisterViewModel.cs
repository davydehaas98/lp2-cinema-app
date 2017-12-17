using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Models;

namespace CinemaWebsite.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name is required!")]
        [StringLength(50, ErrorMessage = "The {0} can't be longer than {1} characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [StringLength(50, ErrorMessage = "The {0} can't be longer than {1} characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Birthday is required!")]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        
        [Required(ErrorMessage = "Gender is required!")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [StringLength(50, ErrorMessage = "The {0} can't be longer than {1} characters")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email (This Email alse be used as your Username)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and max {1} characters long.", MinimumLength = 6)]
        //[RegularExpression("^((?=.*[a-z])(?=.*[A-Z])(?=.*\\d)).+$", ErrorMessage = "Password contains characters that are not allowed.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirming your password is required!")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and max {1} characters long.", MinimumLength = 6)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public RegisterViewModel()
        {

        }
    }
}