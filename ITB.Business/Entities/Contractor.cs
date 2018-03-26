using System;
using System.Collections.Generic;
using System.Text;

namespace ITB.Business
{
    public class Contractor : BaseEntity
    {
        public string SelectedPosition { get; set; }
        //public Dictionary<string, int> PrimarySkillTerms { get; set; } = new Dictionary<string, int>();
        //public Dictionary<string, int> SecondarySkillTerms { get; set; } = new Dictionary<string, int>();
        public List<string> PrimarySkills { get; set; } = new List<string>();
        public List<string> SecondarySkills { get; set; } = new List<string>();
        public ContractType ContractType { get; set; } = ContractType.FullTime;
        public List<string> SelectedCities { get; set; } = new List<string>();
        //public DateTime Availability { get; set; } = DateTime.UtcNow;
        public string WebsiteUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string GithubUrl { get; set; }
        public string StackoverflowUrl { get; set; }
        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<Education> Educations { get; set; } = new List<Education>();
        //public List<Language> Languages { get; set; } = new List<Language>();
        public List<string> Languages { get; set; } = new List<string>();
        public List<Certification> Certificates { get; set; } = new List<Certification>();
        //public byte[] CvFile { get; set; }
    }


    public class Experience
    {
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string JobCity { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public bool CurrentlyWorkHere { get; set; }
        public string Description { get; set; }
    }
    public class Certification
    {
        public string Name { get; set; }
        public string CertDocument { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
    }
    public class Education
    {
        public string Institution { get; set; }
        public string GraduationResult { get; set; }
        //public DateTime GraduationYear { get; set; }
    }
    public class Language
    {
        public string Name { get; set; }
        public LanguageProficiency Proficiency { get; set; }
    }
    public enum LanguageProficiency
    {
        Beginner,
        Intermediate,
        Upperintermediate,
        Advanced,
        Fluent,
        Native
    }
    public enum ContractType
    {
        FullTime,
        PartTime,
        OnSite,
        Remote
    }
}
