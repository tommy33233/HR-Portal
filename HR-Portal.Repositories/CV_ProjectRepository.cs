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
   public class CV_ProjectRepository:IRepository<CV_Project>
    {
        private HRContext db;

        public CV_ProjectRepository(HRContext context)
        {
            this.db = context;
        }

        public IEnumerable<CV_Project> GetAll()
        {
            return db.CV_Projects.ToList();
        }

        public CV_Project Get(int id)
        {
            return db.CV_Projects.Find(id);
        }

        public void Create(CV_Project cv_Proj)
        {
            db.CV_Projects.Add(cv_Proj);
        }

        public void Delete(int id)
        {
            CV_Project cv_Proj = db.CV_Projects.Find(id);
            if (cv_Proj != null)
            {
                db.CV_Projects.Remove(cv_Proj);
            }
        }

        public void Update(CV_Project cv_Proj)
        {
            db.Entry(cv_Proj).State = EntityState.Modified;
        }
    }
}
