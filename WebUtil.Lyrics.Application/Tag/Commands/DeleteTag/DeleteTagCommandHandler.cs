using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Tag.Commands.DeleteTag
{
	public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, DeleteTagResult>
	{
		private readonly ITagRepository _tagRepository;
		private readonly ISongTagRepository _songTagRepository;

		public DeleteTagCommandHandler(ITagRepository tagRepository, ISongTagRepository songTagRepository)
		{
			_tagRepository = tagRepository;
			_songTagRepository = songTagRepository;
		}

		public async Task<DeleteTagResult> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
		{
			var songtags = await _songTagRepository.GetAllAsync();
			if(songtags.Any(st => st.TagCode == request.tagcode))
			{
				throw new Exception();
			}
			var count = await _tagRepository.DeleteByCodeAsync(request.tagcode);
			return new DeleteTagResult(count);
		}
	}
}
