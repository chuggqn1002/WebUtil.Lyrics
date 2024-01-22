using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUtil.Lyrics.Application.Albums.Command.AddAlbum;
using WebUtil.Lyrics.Application.Albums.Command.DeleteAlbum;
using WebUtil.Lyrics.Application.Albums.Command.UpdateAlbum;
using WebUtil.Lyrics.Application.Albums.Query.GetAllAlbums;
using WebUtil.Lyrics.Application.Authors.Command.AddAuthor;
using WebUtil.Lyrics.Application.Authors.Command.DeleteAuthor;
using WebUtil.Lyrics.Application.Authors.Command.UpdateAuthor;
using WebUtil.Lyrics.Application.Authors.Query.GetAllAuthor;
using WebUtil.Lyrics.Contracts.Album.AddAlbum;
using WebUtil.Lyrics.Contracts.Album.GetAllAlbum;
using WebUtil.Lyrics.Contracts.Album.UpdateAlbum;
using WebUtil.Lyrics.Contracts.Author.AddAuthor;
using WebUtil.Lyrics.Contracts.Author.GetAllAuthor;
using WebUtil.Lyrics.Contracts.Author.UpdateAuthor;

namespace WebUtil.Lyrics.Api.Controllers
{
	[Route("author")]
	[AllowAnonymous]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private ISender _mediator;
		private IMapper _mapper;

		public AuthorController(ISender mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllAuthor()
		{
			GetAllAuthorsQuery query = new GetAllAuthorsQuery();
			var queryResult = await _mediator.Send(query);

			var resultResponse = _mapper.Map<GetAllAuthorsResponse>(queryResult);

			return Ok(resultResponse);

		}
		[HttpPost("add")]
		public async Task<IActionResult> AddAuthor(AddAuthorRequest request)
		{
			AddAuthorCommand command = _mapper.Map<AddAuthorCommand>(request);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpPut("update")]
		public async Task<IActionResult> UpdateAuthor(UpdateAuthorRequest request)
		{
			UpdateAuthorCommand command = new UpdateAuthorCommand(request.AuthorCode, request.AuthorName, request.Bio, request.Avatar, request.Status);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteAuthor([FromQuery] string authorcode)
		{
			DeleteAuthorCommand command = new DeleteAuthorCommand(authorcode);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
