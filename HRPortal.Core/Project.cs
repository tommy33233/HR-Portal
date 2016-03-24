using System.Collections.Generic;

namespace HRPortal.Core
{
    public class Project
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public int AmountOfMembersOfTheTeam { get; set; }
        public string Position { get; set; }

        public ICollection<EmployeeProject> EmployeesProjects { get; set; }
        public ICollection<Technology> Technologies { get; set; }
    }
}
