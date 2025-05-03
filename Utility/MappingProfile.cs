using AutoMapper;
using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;
using Newtonsoft.Json;
using static Azure.Core.HttpHeader;

namespace KejaHUnt_PropertiesAPI.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Property -> CreatePropertyRequestDto
            CreateMap<Property, CreatePropertyRequestDto>().ReverseMap();

            // CreatePropertyRequestDto -> Property
            CreateMap<CreatePropertyRequestDto, Property>().ReverseMap();


            CreateMap<Unit, CreateUnitRequestDto>().ReverseMap();

            CreateMap<UpdatePropertyRequestDto, Property>();

            CreateMap<Unit, UnitDto>().ReverseMap();
            
            CreateMap<UpdateUnitRequestDto, Unit>().ReverseMap();

            CreateMap<Property, PropertyDto>().ReverseMap();
        }
    }
}
