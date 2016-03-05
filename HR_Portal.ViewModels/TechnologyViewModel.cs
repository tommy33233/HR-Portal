using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.ViewModels
{
   public class TechnologyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public int YearOfCreation { get; set; }

        public ICollection<ProjectViewModel> Projects { get; set; }
        public ICollection<EmployeeViewModel> Employees { get; set; }
        public ICollection<CV_ProjectViewModel> Cv_Projects { get; set; }
    }
}
