using AutoMapper;
using JulyIdea.Services.AuthAPI.Models;
using JulyIdea.Services.AuthAPI.ViewModels;

namespace JulyIdea.Services.AuthAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserViewModel>()
                    .ReverseMap();
            });

            return mappingConfig;
        }
    }
}
