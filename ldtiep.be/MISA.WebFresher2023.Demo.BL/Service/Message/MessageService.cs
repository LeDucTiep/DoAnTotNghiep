using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Repository;

namespace ldtiep.be.BL.Service
{
    public class MessageService : BaseService<Message, MessageDto, MessageCreateDto, MessageUpdateDto>, IMessageService
    {
        private IMessageRepository _messageRepo;

        public MessageService(
            IMessageRepository messageRepository,

            IMSDatabase msDatabase,
            IMapper mapper) : base(msDatabase, messageRepository, mapper)
        {
            _messageRepo = messageRepository;
        }

        public async Task<List<object>> GetChats()
        {
            return await  _messageRepo.GetChats();
        }

    }
}
