using AutoMapper;
using JulyIdea.Services.MessangerAPI.DbStuff.Models;
using JulyIdea.Services.MessangerAPI.Repositories;
using JulyIdea.Services.MessangerAPI.SignalRHub;
using JulyIdea.Services.MessangerAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JulyIdea.Services.MessangerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IMessageRepository _messageRepository;
        private IMapper _mapper;
        private IHubContext<MessagesHub> _hubContext;
        public MessagesController(IMessageRepository messageRepository,
            IMapper mapper,
            IHubContext<MessagesHub> hub) 
        {
            _hubContext = hub;
            _mapper = mapper;
            _messageRepository = messageRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<MessageViewModel>> GetAll() 
        {
            return _mapper
                .Map<List<MessageViewModel>>(await _messageRepository.GetAll());
        }

        [HttpPost]
        [Authorize]
        public async Task<MessageViewModel> SendMessage(MessageViewModel message) 
        {
            if (ModelState.IsValid) 
            {
                var userId = User.Claims.SingleOrDefault(x => x.Type == "Id").Value; //string

                var dbMessage = _mapper.Map<Message>(message);
                dbMessage.SenderId = long.Parse(userId);
                dbMessage.DateOfSending = DateTime.Now;

                await _messageRepository.Save(dbMessage);

                await _hubContext.Clients.User(userId).SendAsync("ReceiveMessage", message.Text);

                return _mapper.Map<MessageViewModel>(dbMessage);
            }

            return null;
        }
    }
}
