using System;
using System.Collections.Generic;

namespace HRPortal.Core
{
    public class CV
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public Employee Employee { get; set; }
        public ICollection<CVProject> CvProjects { get; set; }
    }
}
