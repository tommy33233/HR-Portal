using HRPortal.Core;
using HRPortal.Repositories;
using HRPortal.Repositories.Context;
using HRPortalInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRPortal.DataAccess.WorkUnit
{
   public class HRPortalUnitOfWork:IUnitOfWork
    {
        private HRContext db;

        public EmployeeRepository employeeRepository;
        public ProjectRepository projectRepository;
        public TechnologyRepository technologieRepository;
        public CVRepository cvRepository;
        public CVProjectRepository cvProjectRepository;
        public EmployeeProjectRepository employeeProjectsRepository;

        public HRPortalUnitOfWork()
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
                if (cvRepository == null)
                {
                    cvRepository = new CVRepository(db);

                }
                return cvRepository;
            }
        }

        public IRepository<CVProject> CVProjects
        {
            get
            {
                if (cvProjectRepository == null)
                {
                    cvProjectRepository = new CVProjectRepository(db);

                }
                return cvProjectRepository;
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
