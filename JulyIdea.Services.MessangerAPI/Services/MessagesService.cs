using JulyIdea.Services.MessangerAPI.Repositories;
using JulyIdea.Services.MessangerAPI.ViewModels;

namespace JulyIdea.Services.MessangerAPI.Services
{
    public class MessagesService : IMessagesService
    {
        private IMessageRepository _messageRepository;

        public MessagesService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Task<DialogViewModel> GetUserdialogs(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
