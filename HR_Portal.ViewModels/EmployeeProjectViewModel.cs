using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_Portal.Core;

namespace HR_Portal.ViewModels
{
   public class EmployeeProjectViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public PositionOnTheProject PositionOnTheProject { get; set; }

        public virtual EmployeeViewModel Employee { get; set; }

        public virtual ProjectViewModel Project { get; set; }
    }
}
