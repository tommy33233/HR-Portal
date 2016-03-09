using HR_Portal.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HR_Portal.Repositories.Context
{
    public class HRContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<CV_Project> CV_Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

    }
}
