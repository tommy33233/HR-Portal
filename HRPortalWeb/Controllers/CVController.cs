using AutoMapper;
using HRPortal.Core;
using HRPortal.ViewModels;
using HRPortalInterfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace HRPortalWeb.Controllers
{
    public class CVController : ApiController
    {
        IUnitOfWork unit;

        public CVController(IUnitOfWork uof)
        {
            unit = uof;
        }

        public void CreateMapForCV()
        { 
            Mapper.CreateMap<CV, CVViewModel>();
            Mapper.CreateMap<CV, CVViewModel>().ForMember(dest => dest.CvProjects, src => src.MapFrom(p => p.CvProjects));           
        }

        public IEnumerable<CVViewModel> GetCV()
        {
            CreateMapForCV();
            return Mapper.Map<IEnumerable<CV>, List<CVViewModel>>(unit.CVs.GetAll());
        }

        public CVViewModel GetCV(int id)
        {
            CreateMapForCV();
            return Mapper.Map<CV, CVViewModel>(unit.CVs.Get(id));
        }

        [HttpPost]
        public void CreateCV([FromBody]CVViewModel cv)
        {
            Mapper.CreateMap<CVViewModel, CV>();
            CV resume = Mapper.Map<CVViewModel, CV>(cv);
            unit.CVs.Create(resume);
            unit.Save();
        }

        [HttpPut]
        public void EditCV( [FromBody]CVViewModel cv)
        {
            CV resume = unit.CVs.Get(cv.Id);
            resume.Id = cv.Id;
            resume.Name = cv.Name;
            resume.Author = cv.Author;
            resume.DateOfCreation = cv.DateOfCreation;
            resume.EmployeeId = cv.EmployeeId;
           
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
