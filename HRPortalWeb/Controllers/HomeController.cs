using HRPortalInterfaces;
using System.Web.Mvc;
using AutoMapper;
using HRPortal.ViewModels;
using HRPortal.Core;

namespace HRPortalWeb.Controllers
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

        public void CreateMapForEmployeeViewModel()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>();
            Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.Technologies, src => src.MapFrom(p => p.Technologies));
            Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.EmployeeProjects, src => src.MapFrom(p => p.EmployeeProjects));
            Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.Cvs, src => src.MapFrom(p => p.Cvs));
        }

        /*   public ActionResult Index()
           {
               CreateMapForEmployee();
               CreateMapForEmployeeViewModel();

               var employees = new List<EmployeeViewModel>();
               foreach (var item in unit.Employees.GetAll())
               {
                   var emp = Mapper.Map<Employee, EmployeeViewModel>(item);
                   employees.Add(emp);
               }
               return View(employees);
              // return View(Mapper.Map<IEnumerable<Employee>, List<EmployeeViewModel>>(unit.Employees.GetAll()));
               // return View(unit.Employees.GetAll());
           }
           */

        public ActionResult Index()
        {
            return View();
        }
/*
        public ActionResult CreateNewEmployee()
        {
            return View();
        }

        public ActionResult DeleteEmployee()
        {
            return View();
        }

        public ActionResult Employees()
        {
            return View();
        }


        public ActionResult Projects()
        {
            return View();
        }
        */

    }
}