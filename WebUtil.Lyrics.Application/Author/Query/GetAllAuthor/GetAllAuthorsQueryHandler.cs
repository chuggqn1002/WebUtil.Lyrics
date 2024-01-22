using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Authors.Query.GetAllAuthor
{
	public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, GetAllAuthorsResult>
	{
		private readonly IAuthorRepository _authorRepository;

		public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public async Task<GetAllAuthorsResult> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
		{
			var result = await _authorRepository.GetAllAsync();
			return new GetAllAuthorsResult(result);
		}
	}
}
