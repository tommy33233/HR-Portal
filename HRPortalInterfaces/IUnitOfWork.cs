using HRPortal.Core;
using System;

namespace HRPortalInterfaces
{
  public  interface IUnitOfWork:IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<Project> Projects { get; }
        IRepository<Technology> Technologies { get; }
        IRepository<CV> CVs { get; }
        IRepository<CVProject> CVProjects { get; }
        IRepository<EmployeeProject> EmployeeProjects { get; }

        void Save();
    }
}
