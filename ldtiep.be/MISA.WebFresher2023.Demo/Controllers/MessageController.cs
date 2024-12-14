using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class MessageController : BaseController<Message, MessageDto, MessageCreateDto, MessageUpdateDto>
    {
        public IMessageService _messageService;
        public MessageController(IMessageService messageService
            ) : base(messageService)
        {
            _messageService = messageService;
        }


        [HttpGet("chats")]
        public virtual async Task<IActionResult> GetChats()
        {
            var res = await _messageService.GetChats();

            return Ok(res);
        }
    }
}
