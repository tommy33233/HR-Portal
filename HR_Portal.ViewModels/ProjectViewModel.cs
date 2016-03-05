using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.ViewModels
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
