using System.Collections.Generic;

namespace HRPortal.ViewModels
{
   public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public int AmountOfMembersOfTheTeam { get; set; }
        public string Position { get; set; }

        public ICollection<EmployeeProjectViewModel> EmployeesProjects { get; set; }
        public ICollection<TechnologyViewModel> Technologies { get; set; }
    }
}
