using AutoMapper;
using HRPortal.Core;
using HRPortal.ViewModels;
using HRPortalInterfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace HRPortalWeb.Controllers
{
    public class CVProjectController : ApiController
    {
        IUnitOfWork unit;

        public CVProjectController(IUnitOfWork uof)
        {
            unit = uof;
        }

        public void CreateMapForCV_Project()
        {
            Mapper.CreateMap<CVProject, CVProjectViewModel>();
            Mapper.CreateMap<CVProject, CVProjectViewModel>().ForMember(dest => dest.Technologies, src => src.MapFrom(p => p.Technologies));
        }

        public IEnumerable<CVProjectViewModel> GetCV_Project()
        {
            CreateMapForCV_Project();
            return Mapper.Map<IEnumerable<CVProject>, List<CVProjectViewModel>>(unit.CVProjects.GetAll());
        }

        public CVProjectViewModel GetCV_Project(int id)
        {
            CreateMapForCV_Project();
            return Mapper.Map<CVProject, CVProjectViewModel>(unit.CVProjects.Get(id));
        }

        [HttpPost]
        public void CreateCV_Project([FromBody]CVProjectViewModel cv_Proj)
        {
            Mapper.CreateMap<CVProjectViewModel, CVProject>();
            CVProject cv_Project = Mapper.Map<CVProjectViewModel, CVProject>(cv_Proj);
            unit.CVProjects.Create(cv_Project);
            unit.Save();
        }

        [HttpPut]
        public void EditCV_Project( [FromBody]CVProjectViewModel cv_Proj)
        {
            CVProject cv_Project = unit.CVProjects.Get(cv_Proj.Id);
            cv_Project.Id = cv_Proj.Id;
            cv_Project.Period = cv_Proj.Period;
            cv_Project.Description = cv_Proj.Description;
            cv_Project.AmountOfMembers = cv_Proj.AmountOfMembers;
            cv_Project.CV_VersionId = cv_Proj.CV_VersionId;           
            unit.CVProjects.Update(cv_Project);
            unit.Save();
        }

        public void DeleteCV_Project(int id)
        {
            unit.CVProjects.Delete(id);
            unit.Save();
        }
    }
}
