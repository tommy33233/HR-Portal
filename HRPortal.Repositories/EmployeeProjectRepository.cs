using HRPortal.Core;
using HRPortal.Repositories.Context;
using HRPortalInterfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HRPortal.Repositories
{
   public class EmployeeProjectRepository:IRepository<EmployeeProject>
    {
        private HRContext db;

        public EmployeeProjectRepository(HRContext context)
        {
            db = context;
        }

        public IEnumerable<EmployeeProject> GetAll()
        {
            return db.EmployeeProjects.ToList();
        }

        public EmployeeProject Get(int id)
        {
            return db.EmployeeProjects.Find(id);
        }

        public void Create(EmployeeProject eProj)
        {
            db.EmployeeProjects.Add(eProj);
        }

        public void Delete(int id)
        {
            EmployeeProject eProj = db.EmployeeProjects.Find(id);
            if (eProj != null)
            {
                db.EmployeeProjects.Remove(eProj);
            }
        }

        public void Update(EmployeeProject eProj)
        {
            db.Entry(eProj).State = EntityState.Modified;
        }
    }
}
