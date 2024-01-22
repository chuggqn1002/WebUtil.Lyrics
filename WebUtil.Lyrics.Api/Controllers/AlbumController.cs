using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUtil.Lyrics.Application.Albums.Command.AddAlbum;
using WebUtil.Lyrics.Application.Albums.Command.DeleteAlbum;
using WebUtil.Lyrics.Application.Albums.Command.UpdateAlbum;
using WebUtil.Lyrics.Application.Albums.Query.GetAllAlbums;
using WebUtil.Lyrics.Application.Categories.Commands.AddCategory;
using WebUtil.Lyrics.Application.Categories.Commands.DeleteCategory;
using WebUtil.Lyrics.Application.Categories.Commands.UpdateCategory;
using WebUtil.Lyrics.Application.Categories.Queries.GetAllCategories;
using WebUtil.Lyrics.Contracts.Album.AddAlbum;
using WebUtil.Lyrics.Contracts.Album.GetAllAlbum;
using WebUtil.Lyrics.Contracts.Album.UpdateAlbum;
using WebUtil.Lyrics.Contracts.Category.AddCategory;
using WebUtil.Lyrics.Contracts.Category.GetAllCategory;
using WebUtil.Lyrics.Contracts.Category.UpdateCategory;

namespace WebUtil.Lyrics.Api.Controllers
{
	[Route("album")]
	[ApiController]
	[Authorize]
	public class AlbumController : ControllerBase
	{
		private ISender _mediator;
		private IMapper _mapper;

		public AlbumController(ISender mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllAlbum()
		{
			GetAllAlbumsQuery query = new GetAllAlbumsQuery();
			var queryResult = await _mediator.Send(query);

			var resultResponse = _mapper.Map<GetAllAlbumsResponse>(queryResult);

			return Ok(resultResponse);

		}
		[HttpPost("add")]
		public async Task<IActionResult> AddAlbum(AddAlbumRequest request)
		{
			AddAlbumCommand command = _mapper.Map<AddAlbumCommand>(request);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpPut("update")]
		public async Task<IActionResult> UpdateAlbum(UpdateAlbumRequest request)
		{
			UpdateAlbumCommand command = new UpdateAlbumCommand(request.AlbumCode, request.AlbumName, request.Released, request.Status);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteAlbum([FromQuery] string albumcode)
		{
			DeleteAlbumCommand command = new DeleteAlbumCommand(albumcode);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
