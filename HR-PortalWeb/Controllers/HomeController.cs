using HR_PortalInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_PortalWeb.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork unit;

        public HomeController(IUnitOfWork uof)
        {
            unit = uof;
        }

        public ActionResult Index()
        {
            return View(unit.Employees.GetAll());
        }
    }
}