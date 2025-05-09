﻿using AutoMapper;
using iDss.X.Models;

namespace iDss.X
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AppModuleCtg, AppModuleCtgDto>()
                    .ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src.Modules));

                config.CreateMap<AppModule, AppModuleDto>()
                    .ForMember(dest => dest.modulectgid, opt => opt.MapFrom(src => src.ModuleCtg.id))
                    .ForMember(dest => dest.modulectgname, opt => opt.MapFrom(src => src.ModuleCtg.modulectgname))
                    .ForMember(dest => dest.totalmenus, opt => opt.MapFrom(src => src.Menus.Count(menu => menu.path != null)))
                    .ForMember(dest => dest.totalactivemenus, opt => opt.MapFrom(src => src.Menus.Count(menu => menu.flag == 1 && menu.path != null)))
                    .ForMember(dest => dest.Menus, opt => opt.MapFrom(src => src.Menus));

                config.CreateMap<AppMenu, AppMenuDto>()
                    .ForMember(dest => dest.isactive, opt => opt.MapFrom(src => src.flag == 1));
            });
            return mappingconfig;
        }
    }
}
