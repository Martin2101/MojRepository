using Autoservis01.Models.DBEntities;
using Autoservis01.Models;
using AutoMapper;

namespace Autoservis01.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Proizvodac, MapperViewModel>().ReverseMap();
        }
    }
}
