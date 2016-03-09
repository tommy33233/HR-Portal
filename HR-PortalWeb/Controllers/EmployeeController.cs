using HR_Portal.ViewModels;
using HR_PortalInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HR_Portal.Core;

namespace HR_PortalWeb.Controllers
{
    public class EmployeeController : ApiController
    {
        IUnitOfWork unit;

        public EmployeeController(IUnitOfWork uof)
        {
            unit = uof;
        }

        public void CreateMapForEmployee()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>();
            Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.Technologies, src => src.MapFrom(p => p.Technologies));
            Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.EmployeeProjects, src => src.MapFrom(p => p.EmployeeProjects));
            Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.Cvs, src => src.MapFrom(p => p.Cvs));
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            CreateMapForEmployee();
            return Mapper.Map<IEnumerable<Employee>,List<EmployeeViewModel>>(unit.Employees.GetAll());
        }

        public EmployeeViewModel GetEmployee(int id)
        {
            CreateMapForEmployee();
            return Mapper.Map<Employee, EmployeeViewModel>(unit.Employees.Get(id));          
        }

        [HttpPost]
        public void CreateEmployee([FromBody]EmployeeViewModel emp)
        {
            CreateMapForEmployee();
            Employee employee = Mapper.Map<EmployeeViewModel, Employee>(emp);
            unit.Employees.Create(employee);
            unit.Save();           
        }

        [HttpPut]
        public void EditEmployee(int id, [FromBody]EmployeeViewModel emp)
        {
            CreateMapForEmployee();
            Employee employee= Mapper.Map<EmployeeViewModel, Employee>(emp);
            unit.Employees.Update(employee);
            unit.Save();
        }

        public void DeleteEmployee(int id)
        {
            unit.Employees.Delete(id);
            unit.Save();   
        }
    }
}
