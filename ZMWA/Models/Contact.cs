using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZMWA.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public int Mobile { get; set; }
        public string Message { get; set; }

    }

    public class ContactDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}