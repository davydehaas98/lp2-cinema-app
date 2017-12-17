using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Models;

namespace CinemaWebsite.ViewModels
{
    public class EditProfileViewModel
    {
        public EditProfileViewModel() { }
        public EditProfileViewModel(Client client)
        {
            this.Id = client.Id;
            this.FirstName = client.FirstName;
            this.LastName = client.LastName;
            this.Birthday = client.Birthday;
            this.Gender = client.Gender;
            this.Email = client.Email;
        }
        [Required]
        public int Id { get; set; }

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
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}