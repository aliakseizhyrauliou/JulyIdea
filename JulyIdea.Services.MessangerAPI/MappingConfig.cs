using AutoMapper;
using JulyIdea.Services.MessangerAPI.DbStuff.Models;
using JulyIdea.Services.MessangerAPI.ViewModels;

namespace JulyIdea.Services.MessangerAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Message, MessageViewModel>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
