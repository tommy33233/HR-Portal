using System.Collections.Generic;

namespace HRPortal.Core
{
   public class CVProject
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }
        public int AmountOfMembers { get; set; }
        public int CV_VersionId { get; set; }

        public CV Cv { get; set; }
        public ICollection<Technology> Technologies { get; set; }
    }
}
