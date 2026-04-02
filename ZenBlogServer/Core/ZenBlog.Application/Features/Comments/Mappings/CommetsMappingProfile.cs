using AutoMapper;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Mappings
{
    public class CommetsMappingProfile : Profile
    {
        public CommetsMappingProfile()
        {
            CreateMap<Comment, GetCommentsQueryResult>().ReverseMap();
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
            CreateMap<Comment, GetCommentByIdQueryResult>().ReverseMap();
            CreateMap<Comment, UpdateCommentCommand>().ReverseMap();

        }
    }
}
