using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Model;

namespace ldtiep.be.BL
{
    /// <summary>
    /// Class dành cho automapper 
    /// </summary>
    /// Author: LeDucTiep (07/06/2023)
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>();
            CreateMap<MessageDto, Message>();
            CreateMap<Message, MessageCreateDto>();
            CreateMap<MessageCreateDto, MessageDto>();
            CreateMap<MessageCreateDto, Message>();
            CreateMap<MessageDto, MessageCreateDto>();
            CreateMap<MessageUpdateDto, Message>();
            CreateMap<MessageUpdateDto, MessageDto>();
            CreateMap<MessageDto, MessageUpdateDto>();
            CreateMap<Message, MessageUpdateDto>();
            CreateMap<BasePage<Message>, BasePage<MessageDto>>();
        }
    }
}
