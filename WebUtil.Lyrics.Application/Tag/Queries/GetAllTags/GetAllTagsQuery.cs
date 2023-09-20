using MediatR;

namespace WebUtil.Lyrics.Application.Tags.Queries.GetAllTags
{
    public record GetAllTagsQuery:IRequest<GetAllTagsResult>;
}
