using HRPortal.Core;
using HRPortal.Repositories.Context;
using HRPortalInterfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace HRPortal.DataAccess
{
   public class CVRepository:IRepository<CV>
    {
        private HRContext db;

        public CVRepository(HRContext context)
        {
            db = context;
        }

        public IEnumerable<CV> GetAll()
        {
            return db.CVs.ToList();
        }

        public CV Get(int id)
        {
            return db.CVs.Find(id);
        }

        public void Create(CV resume)
        {
            db.CVs.Add(resume);
        }

        public void Delete(int id)
        {
            CV cv = db.CVs.Find(id);
            if (cv != null)
            {
                db.CVs.Remove(cv);
            }
        }

        public void Update(CV cv)
        {
            db.Entry(cv).State = EntityState.Modified;
        }
    }
}
