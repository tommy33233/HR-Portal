﻿using HR_Portal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_PortalInterfaces
{
  public  interface IUnitOfWork:IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<Project> Projects { get; }
        IRepository<Technology> Technologies { get; }

        void Save();
    }
}