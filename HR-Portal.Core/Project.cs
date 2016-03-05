﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.Core
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
