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
    public class CV_Controller : ApiController
    {
        IUnitOfWork unit;

        public CV_Controller(IUnitOfWork uof)
        {
            unit = uof;
        }

        public void CreateMapForCV()
        { 
            Mapper.CreateMap<CV, CV_ViewModel>();
            Mapper.CreateMap<CV, CV_ViewModel>().ForMember(dest => dest.Cv_Projects, src => src.MapFrom(p => p.Cv_Projects));           
        }

        public IEnumerable<CV_ViewModel> GetCV()
        {
            CreateMapForCV();
            return Mapper.Map<IEnumerable<CV>, List<CV_ViewModel>>(unit.CVs.GetAll());
        }

        public CV_ViewModel GetCV(int id)
        {
            CreateMapForCV();
            return Mapper.Map<CV, CV_ViewModel>(unit.CVs.Get(id));
        }

        [HttpPost]
        public void CreateCV([FromBody]CV_ViewModel cv)
        {
            CreateMapForCV();
           CV resume = Mapper.Map<CV_ViewModel, CV>(cv);
            unit.CVs.Create(resume);
            unit.Save();
        }

        [HttpPut]
        public void EditCV(int id, [FromBody]CV_ViewModel cv)
        {
            CreateMapForCV();
            CV resume = Mapper.Map<CV_ViewModel, CV>(cv);
            unit.CVs.Update(resume);
            unit.Save();
        }

        public void DeleteCV(int id)
        {
            unit.CVs.Delete(id);
            unit.Save();
        }
    }
}
