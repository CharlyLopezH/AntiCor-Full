using AnticorAPI.DTOs;
using AnticorAPI.Entidades;
using AutoMapper;

namespace AnticorAPI.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {

            CreateMap<Ruspej, RuspejDTO>().ReverseMap();
            CreateMap<Sepifape, SepifapeDTO>()
              .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
              .ForMember(dest => dest.CURP, opt => opt.MapFrom(src => src.CURP))
              .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Nombres))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ReverseMap();
            //CreateMap<ServidorPublico, ServidorPublicoDTO>().ReverseMap();

        }
    }
}
