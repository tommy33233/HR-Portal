using System.Collections.Generic;

namespace HRPortal.Core
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public int YearOfCreation { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<CVProject> CvProjects { get; set; }
    }
}
