using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Tag.Commands.UpdateTag
{
	public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, UpdateTagResult>
	{
		private readonly ITagRepository _tagRepository;

		public UpdateTagCommandHandler(ITagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}

		public async Task<UpdateTagResult> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
		{
			Domain.Entities.Tag? t = await _tagRepository.GetByCodeAsync(request.TagCode); 
			if (t == null)
			{
				throw new Exception("invalid TagCode");
			}
			Domain.Entities.Tag tag = new Domain.Entities.Tag()
			{
				TagCode = request.TagCode,
				TagName = request.TagName,
				Status = request.Status
			};
			int r = await _tagRepository.UpdateAsync(tag);
			return new UpdateTagResult(r);
		}
	}
}
