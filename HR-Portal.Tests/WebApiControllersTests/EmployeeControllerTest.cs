using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HR_PortalInterfaces;
using HR_PortalWeb.Controllers;
using Moq;
using HR_Portal.Core;
using System.Collections.Generic;

namespace HR_Portal.Tests.WebApiControllersTests
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

        public void GetEmployeeByIdTest()
        {
            unit.Setup(x => x.Employees.Get(1)).Returns(new Employee());

            var result = controller.GetEmployee(1);

            Assert.IsNotNull(result);
        }

        public void UpdateEmployeeTest()
        {
          /*  unit.Setup(x => x.Employees.Get(1)).Returns(new Employee());
            Employee emp = new Employee { FirstName = "Test", LastName = "Test" };
            unit.Setup(x => x.Employees.Create(emp));
            var result = controller.CreateEmployee(emp);
            */
        }
    }
}
