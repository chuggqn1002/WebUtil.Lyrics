using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Authors.Command.UpdateAuthor;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;

namespace WebUtil.Lyrics.Application.Singers.Command.UpdateSinger
{
	public class UpdateSingerCommandHandler : IRequestHandler<UpdateSingerCommand, UpdateSingerResult>
	{
		private readonly ISingerRepository _repository;

		public UpdateSingerCommandHandler(ISingerRepository repository)
		{
			_repository = repository;
		}

		public async Task<UpdateSingerResult> Handle(UpdateSingerCommand request, CancellationToken cancellationToken)
		{
			Domain.Entities.Singer? s = await _repository.GetByCodeAsync(request.SingerCode);
			if (s == null)
			{
				throw new Exception("invalid SingerCode");
			}
			Domain.Entities.Singer singer = new Domain.Entities.Singer()
			{
				SingerCode = request.SingerCode,
				SingerName = request.SingerName,
				Bio = request.Bio,
				Avatar = request.Avatar,
				Status = request.Status
			};
			int r = await _repository.UpdateAsync(singer);
			return new UpdateSingerResult(r);
		}
	}
}
