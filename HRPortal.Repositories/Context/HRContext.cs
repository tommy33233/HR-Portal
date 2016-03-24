using HRPortal.Core;
using System.Data.Entity;

namespace HRPortal.Repositories.Context
{
    public class HRContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<CVProject> CVProjects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

    }
}
