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
using HR_Portal.DataAccess;

namespace HR_PortalWeb.Controllers
{
    public class ProjectApiController : ApiController
    {
        private IUnitOfWork unit;
        //=new HR_Portal.DataAccess.WorkUnit.HR_PortalUnitOfWork();

        

        public ProjectApiController(IUnitOfWork uof)
        {
            unit = uof;           
        }   

        public void CreateMapForProjects()
        {
            Mapper.CreateMap<Project, ProjectViewModel>();
            Mapper.CreateMap<Project, ProjectViewModel>().ForMember(dest => dest.Technologies, src => src.MapFrom(p => p.Technologies));
            Mapper.CreateMap<Project, ProjectViewModel>().ForMember(dest => dest.EmployeesProjects, src => src.MapFrom(p => p.EmployeesProjects));          
        }

        public void CreatemapForProjectViewModels()
        {
            Mapper.CreateMap<ProjectViewModel, Project>();
            Mapper.CreateMap<ProjectViewModel, Project>().ForMember(dest => dest.Technologies, src => src.MapFrom(p => p.Technologies));
            Mapper.CreateMap<ProjectViewModel, Project>().ForMember(dest => dest.EmployeesProjects, src => src.MapFrom(p => p.EmployeesProjects));
        }

        [HttpGet]
        public List<ProjectViewModel> GetProjects()
        {
            //CreateMapForProjects();
           CreateMapForProjects();
            CreatemapForProjectViewModels();

            var projects = new List<ProjectViewModel>();
            foreach (var item in unit.Projects.GetAll())
            {
                var proj = Mapper.Map<Project,ProjectViewModel>(item);
                projects.Add(proj);
            }
            return projects;
        }

        public ProjectViewModel GetProject(int id)
        {
            CreateMapForProjects();
            return Mapper.Map<Project, ProjectViewModel>(unit.Projects.Get(id));
        }


        //[FromBody]
        [HttpPost]
        public void AddProject(ProjectViewModel proj)
        {
            // CreateMapForProjects();
            Mapper.CreateMap<ProjectViewModel, Project>();
            Project project = Mapper.Map<ProjectViewModel, Project>(proj);
            unit.Projects.Create(project);
            unit.Save();
        }

        [HttpPut]
        public void EditProject( [FromBody]ProjectViewModel proj)
        {
            // CreateMapForProjects();

            Project project = unit.Projects.Get(proj.Id);
            project.Id = proj.Id;
            project.Period = proj.Period;
            project.Position = proj.Position;
            project.AmountOfMembersOfTheTeam = proj.AmountOfMembersOfTheTeam;
                     
           
            unit.Projects.Update(project);
            unit.Save();
        }

        [HttpDelete]
        public void DeleteProject(int id)
        {
            unit.Projects.Delete(id);
            unit.Save();
        }
    }
}
