using AutoMapper;
using JulyIdea.Services.GroupsAPI.DbStuff.Models;
using JulyIdea.Services.GroupsAPI.ViewModels;

namespace JulyIdea.Services.GroupsAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Group, GroupViewModel>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
