using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUtil.Lyrics.Application.Tags.Queries.GetAllTags;
using WebUtil.Lyrics.Contracts.Tag.GetAllTags;

namespace WebUtil.Lyrics.Api.Controllers
{
    [Route("tags")]
    [ApiController]
    [AllowAnonymous]
    public class TagController: Controller
    {
        private ISender _mediator;
        private IMapper _mapper;

        public TagController(ISender mediator, IMapper mapper )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTag()
        {
            GetAllTagsQuery query = new GetAllTagsQuery();
            var queryResult = await _mediator.Send(query);

            var resultResponse = _mapper.Map<GetAllTagsResponse>(queryResult);

            return Ok(resultResponse);

        }

  
    }
}
