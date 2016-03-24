using System.Collections.Generic;
using System.Linq;
using HRPortal.Core;
using HRPortalInterfaces;
using HRPortal.Repositories.Context;
using System.Data.Entity;

namespace HRPortal.Repositories
{
   public class EmployeeRepository:IRepository<Employee>
    {
        private HRContext db;

        public EmployeeRepository(HRContext context)
        {
            db = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void Delete(int id)
        {
            Employee emp = db.Employees.Find(id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
            }
        }

        public void Update(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
        }
    }
}
