using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Albums.Command.UpdateAlbum;
using WebUtil.Lyrics.Application.Authors.Command.UpdateAuthor;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Author.Command.UpdateAuthor
{
	public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, UpdateAuthorResult>
	{
		private readonly IAuthorRepository _authorRepository;

		public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public async Task<UpdateAuthorResult> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
		{
			Domain.Entities.Author? a = await _authorRepository.GetByCodeAsync(request.AuthorCode);
			if (a == null)
			{
				throw new Exception("invalid AuthorCode");
			}
			Domain.Entities.Author author = new Domain.Entities.Author()
			{
				AuthorCode = request.AuthorCode,
				AuthorName = request.AuthorName,
				Bio = request.Bio,
				Avatar = request.Avatar,
				Status = request.Status
			};
			int r = await _authorRepository.UpdateAsync(author);
			return new UpdateAuthorResult(r);
		}
	}
}
