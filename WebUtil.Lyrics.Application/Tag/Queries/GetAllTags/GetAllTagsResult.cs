

using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Tags.Queries.GetAllTags
{
    public record GetAllTagsResult(IEnumerable<Domain.Entities.Tag> tagList);
    
}
