using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_Portal.Core;
using HR_Portal.Repositories;
using HR_PortalInterfaces;
using HR_Portal.Repositories.Context;
using System.Data.Entity;

namespace HR_Portal.Repositories
{
  public  class TechnologyRepository:IRepository<Technology>
    {
        private HRContext db;

        public TechnologyRepository()
        {
            db = new HRContext();
        }

        public IEnumerable<Technology> GetAll()
        {
            return db.Technologies;
        }

        public Technology Get(int id)
        {
            return db.Technologies.Find(id);
        }

        public void Create(Technology tech)
        {
            db.Technologies.Add(tech);
        }

        public void Delete(int id)
        {
            Technology tech = db.Technologies.Find(id);
            if (tech != null)
            {
                db.Technologies.Remove(tech);
            }
        }

        public void Update(Technology tech)
        {
            db.Entry(tech).State = EntityState.Modified;
        }
    }
}
