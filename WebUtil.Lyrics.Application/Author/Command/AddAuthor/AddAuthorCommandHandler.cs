using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Authors.Command.AddAuthor;
using WebUtil.Lyrics.Application.Categories.Commands.AddCategory;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Author.Command.AddAuthor
{
	public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AddAuthorResult>
	{
		private readonly IAuthorRepository _authorRepository;

		public AddAuthorCommandHandler(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public async Task<AddAuthorResult> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
		{
			List<Domain.Entities.Author> authors = (List<Domain.Entities.Author>)await _authorRepository.GetAllAsync();
			if (authors.Any(author => author.AuthorCode == request.AuthorCode))
			{
				throw new Exception();
			}
			Domain.Entities.Author author = new Domain.Entities.Author()
			{
				AuthorCode = request.AuthorCode,
				AuthorName = request.AuthorName,
				Bio = request.Bio,
				Avatar = request.Avatar,
				Status = request.Status
			};
			int id = await _authorRepository.AddAsync(author);
			//await _cacheManager.DeleteKey("Tag:GetAllAsync");
			return new AddAuthorResult(id);
		}
	}
}
