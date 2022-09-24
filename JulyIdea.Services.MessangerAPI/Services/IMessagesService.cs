using JulyIdea.Services.MessangerAPI.ViewModels;

namespace JulyIdea.Services.MessangerAPI.Services
{
    public interface IMessagesService
    {
        Task<DialogViewModel> GetUserdialogs(long userId);
    }
}
