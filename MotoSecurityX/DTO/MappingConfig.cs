namespace MotoSecurityX.DTO
{
    using AutoMapper;
    using MotoSecurityX.Models;

    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Moto, MotoDTO>().ReverseMap();
            CreateMap<Moto, CreateMotoDTO>().ReverseMap();
            CreateMap<Moto, UpdateMotoDTO>().ReverseMap();
        }
    }
}