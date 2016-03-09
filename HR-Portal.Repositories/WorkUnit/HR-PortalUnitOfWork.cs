using HR_Portal.Core;
using HR_Portal.Repositories.Context;
using HR_PortalInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.Repositories.WorkUnit
{
   public class HR_PortalUnitOfWork:IUnitOfWork
    {
        private HRContext db;

        public EmployeeRepository employeeRepository;
        public ProjectRepository projectRepository;
        public TechnologyRepository technologieRepository;
        public CV_Repository cv_Repository;
        public CV_ProjectRepository cv_ProjectRepository;
        public EmployeeProjectRepository employeeProjectsRepository;

        public HR_PortalUnitOfWork()
        {
            db = new HRContext();
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(db);
                }
                return employeeRepository;
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                if (projectRepository == null)
                {
                   projectRepository = new ProjectRepository(db);
                }
                return projectRepository;
            }
        }

        public IRepository<Technology> Technologies
        {
            get
            {
                if (technologieRepository == null)
                {
                    technologieRepository = new TechnologyRepository(db);
                }
                return technologieRepository;
            }
        }

        public IRepository<EmployeeProject> EmployeeProjects
        {
            get
            {
                if (employeeProjectsRepository == null)
                {
                    employeeProjectsRepository = new EmployeeProjectRepository(db);
               
                }
                return employeeProjectsRepository;
            }
        }

        public IRepository<CV> CVs
        {
            get
            {
                if (cv_Repository == null)
                {
                    cv_Repository = new CV_Repository(db);

                }
                return cv_Repository;
            }
        }

        public IRepository<CV_Project> CV_Projects
        {
            get
            {
                if (cv_ProjectRepository == null)
                {
                    cv_ProjectRepository = new CV_ProjectRepository(db);

                }
                return cv_ProjectRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
