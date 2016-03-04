using HR_Portal.Core;
using HR_Portal.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Portal.Repositories
{
   public class CV_Repository
    {
        private HRContext db;

        public CV_Repository(HRContext context)
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
