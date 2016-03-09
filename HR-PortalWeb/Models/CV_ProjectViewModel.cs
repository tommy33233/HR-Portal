using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.ViewModels
{
   public class CV_ProjectViewModel
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }
        public int AmountOfMembers { get; set; }
        public int CV_VersionId { get; set; }

        public CV_ViewModel Cv { get; set; }
        public ICollection<TechnologyViewModel> Technologies { get; set; }
    }
}
