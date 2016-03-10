using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HR_PortalInterfaces;
using HR_PortalWeb.Controllers;
using HR_Portal.DataAccess.WorkUnit;
using System.Collections.Generic;
using HR_Portal.ViewModels;

namespace HR_Portal.Tests.WebApiControllersTests
{
    [TestClass]
    public class ProjectControllerTest
    {
        private IUnitOfWork unit;
        private ProjectController controller;

        [TestInitialize]
        public void SetupContext()
        {
            unit = new HR_PortalUnitOfWork();
            controller = new ProjectController(unit);
        }

       

        [TestMethod]
        public void GetAllProjectsTest()
        {
            List<ProjectViewModel> proj = new List<ProjectViewModel>();
            var result = controller.GetProjects();
            Assert.IsNotNull(result);
            proj.AddRange(result);
            int numberOfRecords = proj.Count;
            Assert.AreEqual(4, numberOfRecords);
        }

        [TestMethod]
        public void CreateProjectTest()
        {
            List<ProjectViewModel> proj = new List<ProjectViewModel>();
            var resultBeforeCreating = controller.GetProjects();
            proj.AddRange(resultBeforeCreating);

            int countBefore = proj.Count;
           ProjectViewModel project = new ProjectViewModel() { Period="TestPeriod" };
            controller.CreateProject(project);
           

            proj = new List<ProjectViewModel>();
            var resultAfterCreating = controller.GetProjects();
            proj.AddRange(resultAfterCreating);
            int countAfter = proj.Count;
                        
            Assert.AreNotEqual(countBefore, countAfter);
        }

        [TestMethod]
        public void GetProjectTest()
        {
            ProjectViewModel proj = controller.GetProject(2);
            Assert.IsNotNull(proj);
            Assert.AreEqual("TestPeriod", proj.Period);
        }

        [TestMethod]
        public void UpdateProjectTest()
        {
            ProjectViewModel proj = controller.GetProject(3);
            string period = proj.Period;
           proj.Period = "UpdatedPeriod";
            controller.EditProject(proj);
            //unit.Save();

           proj = controller.GetProject(3);

            Assert.AreNotEqual(period, proj.Period);
        }       

        [TestMethod]
        public void DeleteProjectTest()
        {
            ProjectViewModel proj  = controller.GetProject(3);
            Assert.IsNotNull(proj);

            controller.DeleteProject(proj.Id);            
            proj = controller.GetProject(3);
            Assert.IsNull(proj);
        }
    }
}
