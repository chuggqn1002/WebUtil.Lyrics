using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUtil.Lyrics.Application.Authors.Command.AddAuthor;
using WebUtil.Lyrics.Application.Authors.Command.DeleteAuthor;
using WebUtil.Lyrics.Application.Authors.Command.UpdateAuthor;
using WebUtil.Lyrics.Application.Authors.Query.GetAllAuthor;
using WebUtil.Lyrics.Application.Singers.Command.AddSinger;
using WebUtil.Lyrics.Application.Singers.Command.DeleteSinger;
using WebUtil.Lyrics.Application.Singers.Command.UpdateSinger;
using WebUtil.Lyrics.Application.Singers.Query.GetAllSingers;
using WebUtil.Lyrics.Contracts.Author.AddAuthor;
using WebUtil.Lyrics.Contracts.Author.GetAllAuthor;
using WebUtil.Lyrics.Contracts.Author.UpdateAuthor;
using WebUtil.Lyrics.Contracts.Singer.AddSinger;
using WebUtil.Lyrics.Contracts.Singer.GetAllSinger;
using WebUtil.Lyrics.Contracts.Singer.UpdateSinger;

namespace WebUtil.Lyrics.Api.Controllers
{
	[Route("singer")]
	[ApiController]
	[AllowAnonymous]
	public class SingerController : ControllerBase
	{
		private ISender _mediator;
		private IMapper _mapper;

		public SingerController(ISender mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllSinger()
		{
			GetAllSingersQuery query = new GetAllSingersQuery();
			var queryResult = await _mediator.Send(query);

			var resultResponse = _mapper.Map<GetAllSingerResponse>(queryResult);

			return Ok(resultResponse);

		}
		[HttpPost("add")]
		public async Task<IActionResult> AddSinger(AddSingerRequest request)
		{
			AddSingerCommand command = _mapper.Map<AddSingerCommand>(request);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpPut("update")]
		public async Task<IActionResult> UpdateSinger(UpdateSingerRequest request)
		{
			UpdateSingerCommand command = new UpdateSingerCommand(request.SingerCode, request.SingerName, request.Bio, request.Avatar, request.Status);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteSinger([FromQuery] string singercode)
		{
			DeleteSingerCommand command = new DeleteSingerCommand(singercode);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
