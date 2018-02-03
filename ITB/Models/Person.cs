using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITB.Models
{
    public class Person
    {       
        public int Id { get; set; }

        public string IdentityUserId { get; set; }

        // Business
        public string BusinessName { get; set; }
        public string BusinessShortDescription { get; set; }
        public string BusinessLongDescription { get; set; }
        
        // ISociable
        public string Website { get; set; }

        public string StackOverflow { get; set; }

        public string Github { get; set; }

        public string LinkedIn { get; set; }
    }
}