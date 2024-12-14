using ldtiep.be.BL.Dto;

namespace ldtiep.be.BL.Service
{
    public interface IMessageService : IBaseService<MessageDto, MessageCreateDto, MessageUpdateDto>
    {
        Task<List<object>> GetChats();
    }
}
