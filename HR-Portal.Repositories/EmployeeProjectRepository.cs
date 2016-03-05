using HR_Portal.Core;
using HR_Portal.Repositories.Context;
using HR_PortalInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.Repositories
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

        public void Create(EmployeeProject e_Proj)
        {
            db.EmployeeProjects.Add(e_Proj);
        }

        public void Delete(int id)
        {
            EmployeeProject e_Proj = db.EmployeeProjects.Find(id);
            if (e_Proj != null)
            {
                db.EmployeeProjects.Remove(e_Proj);
            }
        }

        public void Update(EmployeeProject e_Proj)
        {
            db.Entry(e_Proj).State = EntityState.Modified;
        }
    }
}
