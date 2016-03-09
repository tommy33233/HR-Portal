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
            Mapper.CreateMap<EmployeeProject, EmployeeProjectViewModel>();
            EmployeeProject employeeProject = Mapper.Map<EmployeeProjectViewModel, EmployeeProject>(emp);
            unit.EmployeeProjects.Create(employeeProject);
            unit.Save();
        }

        [HttpPut]
        public void EditEmployeeProject(int id, [FromBody]EmployeeProjectViewModel emp)
        {
            Mapper.CreateMap<EmployeeProject, EmployeeProjectViewModel>();
            EmployeeProject employeeProject = Mapper.Map<EmployeeProjectViewModel, EmployeeProject>(emp);
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
