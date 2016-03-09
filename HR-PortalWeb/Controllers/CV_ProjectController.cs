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
    public class CV_ProjectController : ApiController
    {
        IUnitOfWork unit;

        public CV_ProjectController(IUnitOfWork uof)
        {
            unit = uof;
        }

        public void CreateMapForCV_Project()
        {
            Mapper.CreateMap<CV_Project, CV_ProjectViewModel>();
            Mapper.CreateMap<CV_Project, CV_ProjectViewModel>().ForMember(dest => dest.Technologies, src => src.MapFrom(p => p.Technologies));
        }

        public IEnumerable<CV_ProjectViewModel> GetCV_Project()
        {
            CreateMapForCV_Project();
            return Mapper.Map<IEnumerable<CV_Project>, List<CV_ProjectViewModel>>(unit.CV_Projects.GetAll());
        }

        public CV_ProjectViewModel GetCV_Project(int id)
        {
            CreateMapForCV_Project();
            return Mapper.Map<CV_Project, CV_ProjectViewModel>(unit.CV_Projects.Get(id));
        }

        [HttpPost]
        public void CreateCV_Project([FromBody]CV_ProjectViewModel cv_Proj)
        {
            CreateMapForCV_Project();
            CV_Project cv_Project = Mapper.Map<CV_ProjectViewModel, CV_Project>(cv_Proj);
            unit.CV_Projects.Create(cv_Project);
            unit.Save();
        }

        [HttpPut]
        public void EditCV_Project(int id, [FromBody]CV_ProjectViewModel cv_Proj)
        {
            CreateMapForCV_Project();
            CV_Project cv_Project = Mapper.Map<CV_ProjectViewModel, CV_Project>(cv_Proj);
            unit.CV_Projects.Update(cv_Project);
            unit.Save();
        }

        public void DeleteCV_Project(int id)
        {
            unit.CV_Projects.Delete(id);
            unit.Save();
        }
    }
}
