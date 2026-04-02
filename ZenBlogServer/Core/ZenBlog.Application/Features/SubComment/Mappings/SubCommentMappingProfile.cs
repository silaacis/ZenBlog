using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Features.SubComment.Commands;
using ZenBlog.Application.Features.SubComment.Result;

namespace ZenBlog.Application.Features.SubComment.Mappings
{
    public class SubCommentMappingProfile : Profile
    {
        public SubCommentMappingProfile()
        {
            CreateMap<ZenBlog.Domain.Entities.SubComment, CreateSubCommentCommand>().ReverseMap();
            CreateMap<ZenBlog.Domain.Entities.SubComment, GetAllSubCommentQueryResult>( ).ReverseMap();
            CreateMap<ZenBlog.Domain.Entities.SubComment, GetSubCommentByIdQueryResult>().ReverseMap();
            CreateMap<ZenBlog.Domain.Entities.SubComment, UpdateSubCommentCommand>().ReverseMap();
        }
    }
}
