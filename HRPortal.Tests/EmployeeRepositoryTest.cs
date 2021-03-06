﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRPortalInterfaces;
using Moq;
using System.Collections.Generic;
using HRPortal.Core;
using HRPortalWeb;
using HRPortal.DataAccess.WorkUnit;

namespace HR_Portal.Tests.RepositoryTest
{
    [TestClass]
    public class EmployeeTest
    {
       private IUnitOfWork unit;
        

        [TestInitialize]
        public void TestSetup()
        {
            unit = new HRPortalUnitOfWork();
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
            Employee employee = new Employee() { FirstName = "Test", LastName = "1" };
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
          
                  
            Employee emp = unit.Employees.Get(1);
            Assert.IsNotNull(emp);
            Assert.AreEqual("Test", emp.FirstName);

        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            Employee emp = unit.Employees.Get(2);
            string name = emp.LastName;
            emp.LastName = "Updated";
            unit.Employees.Update(emp);
            unit.Save();

            emp = unit.Employees.Get(2);

            Assert.AreNotEqual(name, emp.LastName);
        }

        [TestMethod]
        public void DeleteEmployeeTest()
        {
            Employee emp = unit.Employees.Get(2);
            Assert.IsNotNull(emp);
            
           unit.Employees.Delete(2);
            unit.Save();
            emp = unit.Employees.Get(2);
            Assert.IsNull(emp);

        }
    }
}
