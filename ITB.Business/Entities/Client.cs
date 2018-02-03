using System;
using System.Collections.Generic;
using System.Text;

namespace ITB.Business
{
    public class Client : BaseEntity
    {
        // Employee
        public string JobTitle { get; set; }

        // Client
        public string CompanyName { get; set; }
        public byte[] CompanyLogo { get; set; }

        public string CompanyShortDescription { get; set; }
        public string CompanyLongDescription { get; set; }
        public string CompanyLocation { get; set; }
        public string CompanyCategory { get; set; }


        public string WebsiteUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string GithubUrl { get; set; }
    }
}
