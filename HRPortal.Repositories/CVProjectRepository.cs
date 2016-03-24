using HRPortal.Core;
using HRPortal.Repositories.Context;
using HRPortalInterfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace HRPortal.Repositories
{
   public class CVProjectRepository:IRepository<CVProject>
    {
        private HRContext db;

        public CVProjectRepository(HRContext context)
        {
            this.db = context;
        }

        public IEnumerable<CVProject> GetAll()
        {
            return db.CVProjects.ToList();
        }

        public CVProject Get(int id)
        {
            return db.CVProjects.Find(id);
        }

        public void Create(CVProject cvProj)
        {
            db.CVProjects.Add(cvProj);
        }

        public void Delete(int id)
        {
            CVProject cvProj = db.CVProjects.Find(id);
            if (cvProj != null)
            {
                db.CVProjects.Remove(cvProj);
            }
        }

        public void Update(CVProject cvProj)
        {
            db.Entry(cvProj).State = EntityState.Modified;
        }
    }
}
