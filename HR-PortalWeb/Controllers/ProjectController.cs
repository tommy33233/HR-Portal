using AutoMapper;
using HR_Portal.Core;
using HR_Portal.ViewModels;
using HR_PortalInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HR_PortalWeb.Controllers
{
    public class ProjectController : ApiController
    {
        IUnitOfWork unit;

        public ProjectController(IUnitOfWork uof)
        {
            unit = uof;
        }

        public void CreateMapForProjects()
        {
            Mapper.CreateMap<Project, ProjectViewModel>();
            Mapper.CreateMap<Project, ProjectViewModel>().ForMember(dest => dest.Technologies, src => src.MapFrom(p => p.Technologies));
            Mapper.CreateMap<Project, ProjectViewModel>().ForMember(dest => dest.EmployeesProjects, src => src.MapFrom(p => p.EmployeesProjects));          
        }

        public IEnumerable<ProjectViewModel> GetProjects()
        {
            CreateMapForProjects();
            return Mapper.Map<IEnumerable<Project>, List<ProjectViewModel>>(unit.Projects.GetAll());
        }

        public ProjectViewModel GetEmployee(int id)
        {
            CreateMapForProjects();
            return Mapper.Map<Project, ProjectViewModel>(unit.Projects.Get(id));
        }

        [HttpPost]
        public void CreateProject([FromBody]ProjectViewModel proj)
        {
            CreateMapForProjects();
           Project project = Mapper.Map<ProjectViewModel, Project>(proj);
            unit.Projects.Create(project);
            unit.Save();
        }

        [HttpPut]
        public void EditProject(int id, [FromBody]ProjectViewModel proj)
        {
            CreateMapForProjects();
            Project project = Mapper.Map<ProjectViewModel, Project>(proj);
            unit.Projects.Update(project);
            unit.Save();
        }

        public void DeleteProject(int id)
        {
            unit.Projects.Delete(id);
            unit.Save();
        }
    }
}
