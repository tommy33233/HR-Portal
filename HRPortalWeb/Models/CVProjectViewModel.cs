using System.Collections.Generic;

namespace HRPortal.ViewModels
{
   public class CVProjectViewModel
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }
        public int AmountOfMembers { get; set; }
        public int CV_VersionId { get; set; }

        public CVViewModel Cv { get; set; }
        public ICollection<TechnologyViewModel> Technologies { get; set; }
    }
}
