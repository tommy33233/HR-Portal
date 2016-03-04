using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HR_PortalInterfaces;
using Moq;
using System.Collections.Generic;
using HR_Portal.Core;
using HR_PortalWeb;
using HR_Portal.Repositories.WorkUnit;

namespace HR_Portal.Tests.RepositoryTest
{
    [TestClass]
    public class EmployeeTest
    {
       private IUnitOfWork unit;
        

        [TestInitialize]
        public void TestSetup()
        {
            unit = new HR_PortalUnitOfWork();
        }

        [TestMethod]
        public void VerifyUnitDisplaysAllEmployees()
        {
            List<Employee> emp = new List<Employee>();
         
            var result = unit.Employees.GetAll();
            Assert.IsNotNull(result);
            emp.AddRange(result);
            int numberOfRecords =emp.Count;
            Assert.AreEqual(1, numberOfRecords);
        }

        [TestMethod]
        public void CreateNewEmployeeTest()
        {
            List<Employee> emp = new List<Employee>();
            var resultBeforeCreating = unit.Employees.GetAll();
            emp.AddRange(resultBeforeCreating);
            int countBefore = emp.Count;          
            Employee employee = new Employee() { Id=20, FirstName = "Test", LastName = "1" };
            unit.Employees.Create(employee);
            unit.Save();

            emp = new List<Employee>();
            var resultAfterCreating = unit.Employees.GetAll();
            emp.AddRange(resultAfterCreating);
            int countAfter = emp.Count;

            Assert.AreNotEqual(countBefore, countAfter);

        }

        [TestMethod]
        public void GetEmployeeByIdTest()
        {            
            Employee emp = unit.Employees.Get(3);
            Assert.IsNotNull(emp);
            Assert.AreEqual("Test", emp.FirstName);

        }

        [TestMethod]
        public void DeleteEmployeeTest()
        {
            Employee emp = unit.Employees.Get(3);
            Assert.IsNotNull(emp);
            
           unit.Employees.Delete(3);
            unit.Save();
            emp = unit.Employees.Get(3);
            Assert.IsNull(emp);

        }
    }
}
