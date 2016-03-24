using System.Collections.Generic;

namespace HRPortal.ViewModels
{
   public class TechnologyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public int YearOfCreation { get; set; }

        public ICollection<ProjectViewModel> Projects { get; set; }
        public ICollection<EmployeeViewModel> Employees { get; set; }
        public ICollection<CVProjectViewModel> CvProjects { get; set; }
    }
}
