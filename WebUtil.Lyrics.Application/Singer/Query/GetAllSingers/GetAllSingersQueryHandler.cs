using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Singers.Query.GetAllSingers
{
	public class GetAllSingersQueryHandler : IRequestHandler<GetAllSingersQuery, GetAllSingersResut>
	{
		private readonly ISingerRepository _repository;

		public GetAllSingersQueryHandler(ISingerRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetAllSingersResut> Handle(GetAllSingersQuery request, CancellationToken cancellationToken)
		{
			var result = await _repository.GetAllAsync();
			return new GetAllSingersResut(result);
		}
	}
}
