using AutoMapper;
using JulyIdea.Services.ChainElementsAPI.DbStuff.Models;
using JulyIdea.Services.ChainElementsAPI.ViewModels;

namespace JulyIdea.Services.ChainElementsAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ChainElement, ChainElementViewModel>()
                    .ReverseMap();
            });

            return mappingConfig;
        }
    }
}
