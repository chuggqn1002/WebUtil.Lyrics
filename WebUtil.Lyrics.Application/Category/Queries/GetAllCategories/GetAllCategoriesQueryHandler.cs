using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Categories.Queries.GetAllCategories;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Tags.Queries.GetAllTags;

namespace WebUtil.Lyrics.Application.Category.Queries.GetAllCategories
{
	public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, GetAllCategoriesResult>
	{
		private readonly ICategoryRepository _categoryRepository;

		public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<GetAllCategoriesResult> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
		{
			var queryResult = await _categoryRepository.GetAllAsync();
			if (queryResult == null)
			{
				throw new ArgumentNullException("Categories is null");
			}
			return new GetAllCategoriesResult(queryResult);
		}
	}
}
