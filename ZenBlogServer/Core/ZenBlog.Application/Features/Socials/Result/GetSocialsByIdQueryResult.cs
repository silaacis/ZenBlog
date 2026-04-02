using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Result
{
    public class GetSocialsByIdQueryResult : BaseDto
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
