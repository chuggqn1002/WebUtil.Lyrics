
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUtil.Lyrics.Application.Categories.Commands.AddCategory;
using WebUtil.Lyrics.Application.Categories.Commands.DeleteCategory;
using WebUtil.Lyrics.Application.Categories.Commands.UpdateCategory;
using WebUtil.Lyrics.Application.Categories.Queries.GetAllCategories;
using WebUtil.Lyrics.Application.Tag.Commands.AddTag;
using WebUtil.Lyrics.Application.Tag.Commands.DeleteTag;
using WebUtil.Lyrics.Application.Tag.Commands.UpdateTag;
using WebUtil.Lyrics.Application.Tags.Queries.GetAllTags;
using WebUtil.Lyrics.Contracts.Category.AddCategory;
using WebUtil.Lyrics.Contracts.Category.GetAllCategory;
using WebUtil.Lyrics.Contracts.Category.UpdateCategory;
using WebUtil.Lyrics.Contracts.Tag.AddTag;
using WebUtil.Lyrics.Contracts.Tag.GetAllTags;
using WebUtil.Lyrics.Contracts.Tag.UpdateTag;

namespace WebUtil.Lyrics.Api.Controllers
{
	[Route("categories")]
	[ApiController]
	[AllowAnonymous]
	public class CategoryController : ControllerBase
	{
		private ISender _mediator;
		private IMapper _mapper;

		public CategoryController(ISender mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllCategory()
		{
			GetAllCategoriesQuery query = new GetAllCategoriesQuery();
			var queryResult = await _mediator.Send(query);

			var resultResponse = _mapper.Map<GetAllCategoriesResponse>(queryResult);

			return Ok(resultResponse);

		}
		[HttpPost("add")]
		public async Task<IActionResult> AddCategory(AddCategoryRequest request)
		{
			AddCategoryCommand command = _mapper.Map<AddCategoryCommand>(request);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpPut("update")]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request)
		{
			UpdateCategoryCommand command = new UpdateCategoryCommand(request.CategoryCode, request.CategoryName, request.Status);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteCategory([FromQuery] string categorycode)
		{
			DeleteCategoryCommand command = new DeleteCategoryCommand(categorycode);
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
