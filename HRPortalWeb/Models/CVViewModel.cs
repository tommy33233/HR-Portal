using System;
using System.Collections.Generic;

namespace HRPortal.ViewModels
{
   public class CVViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public EmployeeViewModel Employee { get; set; }
        public ICollection<CVProjectViewModel> CvProjects { get; set; }
    }
}
