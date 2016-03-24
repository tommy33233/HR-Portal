using System.Collections.Generic;
using System.Linq;
using HRPortal.Core;
using HRPortalInterfaces;
using HRPortal.Repositories.Context;
using System.Data.Entity;

namespace HRPortal.Repositories
{
   public class ProjectRepository:IRepository<Project>
    {
        private HRContext db;

        public ProjectRepository(HRContext context)
        {
            db = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects.ToList();
        }

        public Project Get(int id)
        {
            return db.Projects.Find(id);
        }

        public void Create(Project proj)
        {
            db.Projects.Add(proj);
        }

        public void Delete(int id)
        {
            Project proj = db.Projects.Find(id);
            if (proj != null)
            {
                db.Projects.Remove(proj);
            }
        }

        public void Update(Project proj)
        {
            db.Entry(proj).State = EntityState.Modified;
        }
    }
}
