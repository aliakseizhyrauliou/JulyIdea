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
                .ForMember(nameof(IdeaViewModel.CategoryString),
                    opt => opt
                    .MapFrom(dbModel =>
                        dbModel.Category.ToString()))
                    .ReverseMap();
            });

            return mappingConfig;
        }
    }
}
