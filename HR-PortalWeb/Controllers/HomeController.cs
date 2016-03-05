using HR_PortalInterfaces;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HR_Portal.ViewModels;
using HR_Portal.Core;

namespace HR_PortalWeb.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork unit;
      
        public HomeController(IUnitOfWork uof)
        {
            unit = uof;
        }

        public void CreateMapForEmployee()
        {
            Mapper.CreateMap<EmployeeViewModel, Employee>();
            Mapper.CreateMap<EmployeeViewModel, Employee>().ForMember(dest => dest.Technologies, src => src.MapFrom(p => p.Technologies));
            Mapper.CreateMap<EmployeeViewModel, Employee>().ForMember(dest => dest.EmployeeProjects, src => src.MapFrom(p => p.EmployeeProjects));
            Mapper.CreateMap<EmployeeViewModel, Employee>().ForMember(dest => dest.Cvs, src => src.MapFrom(p => p.Cvs));
        }

        public ActionResult Index()
        {
            return View(unit.Employees.GetAll());
        }

        public ActionResult CreateNewEmployee()
        {
            return View();
        }

        public ActionResult DeleteEmployee()
        {
            return View();
        }

     

    }
}