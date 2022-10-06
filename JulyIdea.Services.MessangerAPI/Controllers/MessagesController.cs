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
                var messageViewModel = _mapper.Map<MessageViewModel>(dbMessage);

                await _hubContext.Clients.User(message.ReceiverId.ToString()).SendAsync("ReceiveMessage", messageViewModel);

                return messageViewModel;
            }

            return null;
        }

        [Authorize]
        [HttpGet]

        public List<DialogViewModel> GetUserDialogs()
        {

            var resultDialogs = new List<DialogViewModel>();

            var userId = long.Parse(User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
            var dialogUserIds = _messageRepository.GetUsersIdFormUserDialogs(userId); //Tuple<UserName, UserId>

            foreach (var Id in dialogUserIds)
            {
                resultDialogs.Add(new DialogViewModel()
                {
                    UserId = Id.Item2,
                    OwnerId = userId,
                    UserName = Id.Item1,
                    LastMessage = _mapper.Map<MessageViewModel>(_messageRepository.GetLastMessageOfTwoUser(userId, Id.Item2))
                });
            }

            return resultDialogs;
        }

        [HttpGet]
        [Authorize]
        public List<MessageViewModel> GetMessagesOfTwoUsers(long companionId) 
        {
            var userId = long.Parse(User.Claims.SingleOrDefault(x => x.Type == "Id").Value);
            var messages = _messageRepository.GetMessagesOfTwoUser(companionId, userId);

            return _mapper.Map<List<MessageViewModel>>(messages);


        }

        [HttpGet]
        [Authorize]

        public IActionResult CheckServer() 
        {
            return Ok();
        }

        
    }
}
