using AutoMapper;
using Schindler.ElavatorStatus.WebService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
