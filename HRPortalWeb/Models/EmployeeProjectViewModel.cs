using HRPortal.Core;

namespace HRPortal.ViewModels
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
