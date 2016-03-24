using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRPortalInterfaces;
using HRPortalWeb.Controllers;
using Moq;
using HRPortal.Core;
using System.Collections.Generic;
using HRPortal.ViewModels;


namespace HRPortal.Tests.WebApiControllersTests
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private Mock<IUnitOfWork> unit;
        private EmployeeController controller;
        
         [TestInitialize]
        public void SetupContext()
        {
            unit = new Mock<IUnitOfWork>();
            controller = new EmployeeController(unit.Object);
        }

        [TestMethod]
        public void GetAllEmployeesTest()
        {

            unit.Setup(x => x.Employees.GetAll()).Returns(new List<Employee>());
            var indexResult = controller.GetEmployees();
          

            Assert.IsNotNull(indexResult);
            
        }

        [TestMethod]
        public void GetEmployeeByIdTest()
        {
            unit.Setup(x => x.Employees.Get(1)).Returns(new Employee());

            var result = controller.GetEmployee(1);

            Assert.IsNotNull(result);          
        }

        [TestMethod]
        public void CreateEmployeeApiTest()
        {
          /* 
            unit.Setup(x => x.Employees.Create(new Employee())).Verifiable();
            var employee = new EmployeeViewModel() { FirstName = "TestEmployee" };
            controller.CreateEmployee(employee);
            unit.Verify();  
          */               
        }

        [TestMethod]
        public void UpdateEmployeeApiTest()
        {
                    
        }

        [TestMethod]
        public void DeleteEmployeeApiTest()
        {
          
        }
    }
}
