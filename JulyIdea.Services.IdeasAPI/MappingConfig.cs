using AutoMapper;
using JulyIdea.Services.IdeasAPI.DbStuff.Models;
using JulyIdea.Services.IdeasAPI.ViewModels;

namespace JulyIdea.Services.IdeasAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Idea, IdeaViewModel>()
                    .ReverseMap();

                config.CreateMap<ChainElement, ChainElementViewModel>()
                    .ForMember(nameof(ChainElementViewModel.RootIdeaId),
                        i => i
                        .MapFrom(db => db.RootIdea.Id))
                    .ReverseMap();

            });

            return mappingConfig;
        }
    }
}
