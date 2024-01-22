using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUtil.Lyrics.Application.Songs.Commands.AddSong;
using WebUtil.Lyrics.Application.Songs.Queries.GetAllSongs;
using WebUtil.Lyrics.Application.Songs.Queries.GetASongById;
using WebUtil.Lyrics.Application.Songs.Queries.GetSongPagedList;
using WebUtil.Lyrics.Application.Songs.Queries.SearchSong;
using WebUtil.Lyrics.Contracts.SongContract.AddSong;
using WebUtil.Lyrics.Contracts.SongContract.GetSongById;
using WebUtil.Lyrics.Contracts.SongContract.GetSongPagedList;
using WebUtil.Lyrics.Contracts.SongContract.SearchSong;
using WebUtil.Lyrics.Domain.Entities;

namespace WebUtil.Lyrics.Api.Controllers
{
    [Route("song")]
    [ApiController]
    [AllowAnonymous]
    public class SongController : Controller
    {

        private ISender _mediator;
        private IMapper _mapper;

        public SongController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            GetAllSongsQuery query = new GetAllSongsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("getsong")]
        public async Task<IActionResult> GetSong([FromQuery]GetSongByIdRequest request)
        {
            Guid Suid = request.Suid;
            GetASongByIdQuery getASongByIdQuery = new GetASongByIdQuery(Suid);
            var result = await _mediator.Send<GetASongByIdResult>(getASongByIdQuery);
            return Ok(result);
        }

        [HttpGet("getsonglist")]
        public async Task<IActionResult> GetSongList([FromQuery] GetSongPagedListQuery request)
        {
            int pageNum = (request.pageNum <= 0)?1: request.pageNum;
            int pageSize = (request.pageSize <= 0)?10: request.pageSize;
            GetSongPagedListQuery query = new GetSongPagedListQuery(pageNum, pageSize);
            var queryResult = await _mediator.Send(query);
            var songListResponse = _mapper.Map<GetSongPagedListResponse>(queryResult);
            return Ok(songListResponse);

         
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchSong([FromQuery]string query)
        {
            SearchSongQuery q = new SearchSongQuery(query);
            var result = await _mediator.Send(q);
            var response = _mapper.Map<SearchSongResponse>(result);
            return Ok(result);
        }

        [HttpPost("add")]
        //[Authorize]
        public async Task<IActionResult> AddSong(AddSongRequest request)
        {
            AddSongCommand command = new AddSongCommand
                (
                    request.SongCode,
					request.Title,
		            request.Album,
		            request.Author,
		            request.Singer,
		            request.ImgUrl,
		            request.YtbCode,
		            request.VideoLink,
		            request.Description,
					request.Released,
					request.Status,
					request.Song_Lines
				);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
