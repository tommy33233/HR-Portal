﻿using AutoMapper;
using HRPortal.Core;
using HRPortal.ViewModels;
using HRPortalInterfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace HRPortalWeb.Controllers
{
    public class EmployeeProjectController : ApiController
    {
        IUnitOfWork unit;

        public EmployeeProjectController(IUnitOfWork uof)
        {
            unit = uof;
        }

        /*  public void CreateMapForEmployee()
          {
              Mapper.CreateMap<EmployeeProject, EmployeeProjectViewModel>();
              Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.Technologies, src => src.MapFrom(p => p.Technologies));
              Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.EmployeeProjects, src => src.MapFrom(p => p.EmployeeProjects));
              Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.Cvs, src => src.MapFrom(p => p.Cvs));
          }
          */

        public IEnumerable<EmployeeProjectViewModel> GetEmployeeProjects()
        {
            Mapper.CreateMap<EmployeeProject, EmployeeProjectViewModel>();
            return Mapper.Map<IEnumerable<EmployeeProject>, List<EmployeeProjectViewModel>>(unit.EmployeeProjects.GetAll());
        }

        public EmployeeProjectViewModel GetEmployeeProject(int id)
        {
            Mapper.CreateMap<EmployeeProject, EmployeeProjectViewModel>();
            return Mapper.Map<EmployeeProject, EmployeeProjectViewModel>(unit.EmployeeProjects.Get(id));
        }

        [HttpPost]
        public void CreateEmployeeProject([FromBody]EmployeeProjectViewModel emp)
        {
            Mapper.CreateMap<EmployeeProjectViewModel, EmployeeProject>();
            EmployeeProject employeeProject = Mapper.Map<EmployeeProjectViewModel, EmployeeProject>(emp);
            unit.EmployeeProjects.Create(employeeProject);
            unit.Save();
        }

        [HttpPut]
        public void EditEmployeeProject(int id, [FromBody]EmployeeProjectViewModel emp)
        {
           
            EmployeeProject employeeProject = unit.EmployeeProjects.Get(emp.Id);
            employeeProject.Id = emp.Id;
            employeeProject.Description = emp.Description;
            employeeProject.PositionOnTheProject = emp.PositionOnTheProject;
            
            unit.EmployeeProjects.Update(employeeProject);
            unit.Save();
        }

        public void DeleteEmployeeProject(int id)
        {
            unit.EmployeeProjects.Delete(id);
            unit.Save();
        }
    }
}
