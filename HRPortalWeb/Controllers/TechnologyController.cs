using AutoMapper;
using HRPortal.Core;
using HRPortal.ViewModels;
using HRPortalInterfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace HRPortalWeb.Controllers
{
    public class TechnologyController : ApiController
    {
        IUnitOfWork unit;

        public TechnologyController(IUnitOfWork uof)
        {
            unit = uof;
        }

        public void CreateMapForTechnology()
        {
            Mapper.CreateMap<Technology, TechnologyViewModel>();
            Mapper.CreateMap<Technology, TechnologyViewModel>().ForMember(dest => dest.CvProjects, src => src.MapFrom(p => p.CvProjects));
            Mapper.CreateMap<Technology, TechnologyViewModel>().ForMember(dest => dest.Employees, src => src.MapFrom(p => p.Employees));
            Mapper.CreateMap<Technology, TechnologyViewModel>().ForMember(dest => dest.Projects, src => src.MapFrom(p => p.Projects));
        }

        public IEnumerable<TechnologyViewModel> GetTechnology()
        {
            CreateMapForTechnology();
            return Mapper.Map<IEnumerable<Technology>, List<TechnologyViewModel>>(unit.Technologies.GetAll());
        }

        public TechnologyViewModel GetTechnology(int id)
        {
            CreateMapForTechnology();
            return Mapper.Map<Technology, TechnologyViewModel>(unit.Technologies.Get(id));
        }

        [HttpPost]
        public void CreateTechnology([FromBody]TechnologyViewModel tech)
        {
            CreateMapForTechnology();
            Technology technology = Mapper.Map<TechnologyViewModel, Technology>(tech);
            unit.Technologies.Create(technology);
            unit.Save();
        }

        [HttpPut]
        public void EditTEchnology( [FromBody]TechnologyViewModel tech)
        {
         
            Technology technology =unit.Technologies.Get(tech.Id);
            technology.Id = tech.Id;
            technology.Name = tech.Name;
            technology.Version = tech.Version;
            technology.YearOfCreation = tech.YearOfCreation;
          
            unit.Technologies.Update(technology);
            unit.Save();
        }

        public void DeleteTechnology(int id)
        {
            unit.Technologies.Delete(id);
            unit.Save();
        }
    }
}
