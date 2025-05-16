using MotoSecurityX.DTO;

namespace MotoSecurityX.Mapping
{
    using AutoMapper;
    using MotoSecurityX.Domain;

    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Moto, MotoDTO>().ReverseMap();
            CreateMap<Patio, PatioDTO>().ReverseMap();

        }
    }
}