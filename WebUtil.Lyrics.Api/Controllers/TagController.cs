using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUtil.Lyrics.Application.Tag.Commands.AddTag;
using WebUtil.Lyrics.Application.Tag.Commands.DeleteTag;
using WebUtil.Lyrics.Application.Tag.Commands.UpdateTag;
using WebUtil.Lyrics.Application.Tags.Queries.GetAllTags;
using WebUtil.Lyrics.Contracts.Tag.AddTag;
using WebUtil.Lyrics.Contracts.Tag.GetAllTags;
using WebUtil.Lyrics.Contracts.Tag.UpdateTag;

namespace WebUtil.Lyrics.Api.Controllers
{
    [Route("tags")]
    [ApiController]
    [AllowAnonymous]
    public class TagController : Controller
    {
        private ISender _mediator;
        private IMapper _mapper;

        public TagController(ISender mediator, IMapper mapper)
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
        [HttpPost("add")]
        public async Task<IActionResult> AddTag(AddTagRequest request)
        {
            AddTagCommand command = _mapper.Map<AddTagCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateTag(UpdateTagRequest request)
        {
            UpdateTagCommand command = new UpdateTagCommand(request.TagCode, request.TagName, request.Status);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTag([FromQuery]string tagcode)
        {
            DeleteTagCommand command = new DeleteTagCommand(tagcode);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
  
    }
}
