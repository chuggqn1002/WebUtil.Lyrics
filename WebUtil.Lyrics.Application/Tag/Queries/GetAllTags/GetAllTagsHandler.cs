using MediatR;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Tags.Queries.GetAllTags;

namespace WebUtil.Lyrics.Application.Tags.Queries.GetAllTags
{
    public class GetAllTagsHandler : IRequestHandler<GetAllTagsQuery, GetAllTagsResult>
    {
        private ITagRepository _tagRepository;

        public GetAllTagsHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<GetAllTagsResult> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _tagRepository.GetAllAsync();
            if (queryResult == null) {
                throw new ArgumentNullException("Tags is null");
            }
            return new GetAllTagsResult(queryResult);
        }
    }
}
