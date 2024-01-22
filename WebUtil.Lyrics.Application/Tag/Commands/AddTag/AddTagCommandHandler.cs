using MediatR;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Common.Interfaces.Services;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Application.Tag.Commands.AddTag
{
	public class AddTagCommandHandler : IRequestHandler<AddTagCommand, AddTagResult>
	{
		private readonly ITagRepository _tagRepository;
		private readonly ICacheManager _cacheManager;

		public AddTagCommandHandler(ITagRepository tagRepository, ICacheManager cacheManager)
		{
			_tagRepository = tagRepository;
			_cacheManager = cacheManager;
		}

		public async Task<AddTagResult> Handle(AddTagCommand request, CancellationToken cancellationToken)
		{
			List<Domain.Entities.Tag> tags =(List<Domain.Entities.Tag>) await _tagRepository.GetAllAsync();
			if(tags.Any(tag => tag.TagCode == request.TagCode))
			{
				throw new Exception();
			}
			Domain.Entities.Tag tag = new Domain.Entities.Tag()
			{
				TagCode = request.TagCode,
				TagName = request.TagName,
				Status = request.Status
			};
			int id = await _tagRepository.AddAsync(tag);
			//await _cacheManager.DeleteKey("Tag:GetAllAsync");
			return new AddTagResult(id);
		}
	}
}
