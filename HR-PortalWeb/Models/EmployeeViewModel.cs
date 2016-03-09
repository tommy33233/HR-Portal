using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.ViewModels
{
   public class EmployeeViewModel
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
        public string EngFirstName { get; set; }
        public string EnglastName { get; set; }
        public string EngPosition { get; set; }
        public string EngEducationInstitution { get; set; }
        public string EngSpecialization { get; set; }


        public ICollection<TechnologyViewModel> Technologies { get; set; }
        public ICollection<EmployeeProjectViewModel> EmployeeProjects { get; set; }
        public ICollection<CV_ViewModel> Cvs { get; set; }
    }
}
