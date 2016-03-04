using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.Core
{
    public class Employee
    {       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EducationInstitution { get; set; }
        public string Specialization { get; set; }
        public int? YearOfGraduation { get; set; }
        public string EnglishReadingLevel { get; set; }
        public string EnglishWritingLevel { get; set; }
        public string EnglishSpeakingLevel { get; set; }
    }
}
