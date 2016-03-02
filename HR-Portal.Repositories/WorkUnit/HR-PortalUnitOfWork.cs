﻿using HR_Portal.Core;
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
                    employeeRepository = new EmployeeRepository();
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
                   projectRepository = new ProjectRepository();
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
                    technologieRepository = new TechnologyRepository();
                }
                return technologieRepository;
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