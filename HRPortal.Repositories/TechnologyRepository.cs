using System.Collections.Generic;
using System.Linq;
using HRPortal.Core;
using HRPortalInterfaces;
using HRPortal.Repositories.Context;
using System.Data.Entity;

namespace HRPortal.Repositories
{
  public  class TechnologyRepository:IRepository<Technology>
    {
        private HRContext db;

        public TechnologyRepository(HRContext context)
        {
            db = context;
        }

        public IEnumerable<Technology> GetAll()
        {
            return db.Technologies.ToList();
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
