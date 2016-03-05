﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.Core
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public int YearOfCreation { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<CV_Project> Cv_Projects { get; set; }
    }
}
