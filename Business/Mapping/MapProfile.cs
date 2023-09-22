using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<MyService, MyServiceDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Experience, ExperienceDto>().ReverseMap();
            CreateMap<Work, WorkDto>().ReverseMap();
            CreateMap<ContactForm, ContactFormDto>().ReverseMap();
            CreateMap<ContactAddress, ContactAddressDto>().ReverseMap();
        }
    }
}
