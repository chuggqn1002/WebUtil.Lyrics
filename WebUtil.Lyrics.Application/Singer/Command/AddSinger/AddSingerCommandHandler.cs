using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Singers.Command.AddSinger
{
	public class AddSingerCommandHandler : IRequestHandler<AddSingerCommand, AddSingerResult>
	{
		private readonly ISingerRepository _repository;

		public AddSingerCommandHandler(ISingerRepository repository)
		{
			_repository = repository;
		}

		public async Task<AddSingerResult> Handle(AddSingerCommand request, CancellationToken cancellationToken)
		{
			List<Domain.Entities.Singer> singers = (List<Domain.Entities.Singer>)await _repository.GetAllAsync();
			if (singers.Any(singer => singer.SingerCode == request.SingerCode))
			{
				throw new Exception();
			}
			Domain.Entities.Singer singer = new Domain.Entities.Singer()
			{
				SingerCode = request.SingerCode,
				SingerName = request.SingerName,
				Bio = request.Bio,
				Avatar = request.Avatar,
				Status = request.Status
			};
			int id = await _repository.AddAsync(singer);
			return new AddSingerResult(id);
		}
	}
}
