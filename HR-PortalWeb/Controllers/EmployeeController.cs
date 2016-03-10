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
            Mapper.CreateMap<EmployeeViewModel, Employee>();
            Employee employee = Mapper.Map<EmployeeViewModel, Employee>(emp);
            unit.Employees.Create(employee);
            unit.Save();           
        }

        [HttpPut]
        public void EditEmployee( [FromBody]EmployeeViewModel emp)
        {

            Employee employee = unit.Employees.Get(emp.Id);
            employee.Id = emp.Id;
            employee.LastName = emp.LastName;
            employee.FirstName = emp.FirstName;
            employee.DateOfBirth = emp.DateOfBirth;
            employee.EducationInstitution = emp.EducationInstitution;
            employee.EngEducationInstitution = emp.EngEducationInstitution;
            employee.EngFirstName = emp.EngFirstName;
            employee.EnglastName = emp.EnglastName;
            employee.EnglishReadingLevel = emp.EnglishReadingLevel;
            employee.EnglishSpeakingLevel = emp.EnglishSpeakingLevel;
            employee.EnglishWritingLevel = emp.EnglishWritingLevel;
            employee.EngPosition = emp.EngPosition;
            employee.EngSpecialization = emp.EngSpecialization;
            employee.Position = emp.Position;
            employee.Specialization = emp.Specialization;
            employee.YearOfGraduation = emp.YearOfGraduation;

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
