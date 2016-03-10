using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HR_PortalWeb.Controllers;
using System.Web.Mvc;
using HR_PortalInterfaces;
using Moq;
using HR_Portal.Core;
using System.Collections.Generic;

namespace HR_Portal.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        private  Mock<IUnitOfWork> unit;
        private HomeController controller;
       

        [TestInitialize]
        public void SetupContext()
        {
            unit = new Mock<IUnitOfWork>();
            controller = new HomeController(unit.Object);                     
        }


        [TestMethod]
        public void IndexViewModelNotNull()
        {            
            unit.Setup(x => x.Employees.GetAll()).Returns(new List<Employee>());
            var indexResult = controller.Index() as ViewResult;
            Assert.IsNotNull(indexResult);
        }

        [TestMethod]
        public void VerifyIndexDisplaysAllEmployees()
        {
            unit.Setup(x => x.Employees.GetAll()).Returns(new List<Employee>()
                {
                    new Employee() { Id=1, FirstName="Jack", LastName="Collback",Position=".Net developer" },
                    new Employee() { Id=2, FirstName="Jonjo", LastName="Shelvy"},
                    new Employee() { Id=3, FirstName="Andros", LastName="Townsend"}
                });

            var indexResult=controller.Index() as ViewResult;

            var employees = indexResult.ViewData.Model as List<Employee>;

            Assert.AreEqual(3, employees.Count);
            Assert.AreEqual(1, employees[0].Id);
            Assert.AreEqual("Jonjo", employees[1].FirstName);

        }

    }
}
