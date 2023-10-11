using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUtil.Lyrics.Application.Songs.Queries.GetASongById;
using WebUtil.Lyrics.Application.Songs.Queries.GetSongPagedList;
using WebUtil.Lyrics.Contracts.SongContract.GetSongById;
using WebUtil.Lyrics.Contracts.SongContract.GetSongPagedList;

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

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddSong(AddSongRequest request) { 
            
        
        }
    }
}
