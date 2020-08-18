using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreHouse.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [MinLength(5)]
        public string UserName
        {
            get;
            set;
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [PasswordPropertyText]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]

        public string ConfirmPassword { get; set; }

    


    }
}
