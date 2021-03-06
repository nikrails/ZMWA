﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZMWA.Models
{
    public class PostResume
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

         [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required(ErrorMessage ="Pin code is mandatory")]
        [DataType(DataType.PostalCode)]
        public int PinCode { get; set; }

        
        public string LastEmployer { get; set; }

        public int Experience { get; set; }

        public string Source { get; set; }

        
        [FileExtensions(Extensions = "txt,doc,docx,pdf", ErrorMessage = "Please upload valid format")]
        public virtual ICollection<File> Files { get; set; }

    }
}
