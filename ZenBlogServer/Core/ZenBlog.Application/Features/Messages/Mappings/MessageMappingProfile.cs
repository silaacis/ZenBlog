using AutoMapper;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Mappings
{
    public class MessageMappingProfile : Profile
    {
        public MessageMappingProfile()
        {
            CreateMap<Message, CreateMessageCommand>().ReverseMap();
            CreateMap<Message, GetMessagesQueryResult>().ReverseMap();
            CreateMap<Message, GetMessagesByIdQueryResult>().ReverseMap();
            CreateMap<Message, UpdateMessageCommand>().ReverseMap();
            CreateMap<Message, GetUnReadMessagesQueryResult>().ReverseMap();
            CreateMap<Message, GetReadMessagesQueryResult>().ReverseMap();
        }
    }
}
