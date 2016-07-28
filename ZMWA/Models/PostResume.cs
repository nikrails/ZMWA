using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZMWA.Models
{
    public class PostResume
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public int PhoneNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int PinCode { get; set; }
        public string LastEmployer { get; set; }
        public string Experience { get; set; }
        public string Source { get; set; }

    }
}
