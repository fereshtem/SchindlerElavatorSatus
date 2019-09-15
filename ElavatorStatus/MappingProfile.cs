using AutoMapper;
using Schindler.ElavatorStatus.WebService.Model;

namespace Schindler.ElavatorStatus.WebService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Schindler.ElavatorStatus.Domain.ElavatorStatus, ElavatorStatusModel>();
            CreateMap<ElavatorStatusModel, Schindler.ElavatorStatus.Domain.ElavatorStatus>();
        }
    }
}
