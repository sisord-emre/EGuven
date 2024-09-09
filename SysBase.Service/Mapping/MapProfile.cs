using AutoMapper;
using SysBase.Core.DTOs;
using SysBase.Core.Models;

namespace SysBase.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Menu, MenuDto>().ReverseMap();//ReverseMap dersek tam terside çevrilebiliyor, "Menu" yü "MenüDto" ya veya tam tersi
            CreateMap<Config, ConfigDto>().ReverseMap();
            CreateMap<LanguageValue, LanguageValuesWithLanguageKeyDto>();//tek taraflı LanguageValue den LanguageValuesWithLanguageKeyDto ya
        }
    }
}
