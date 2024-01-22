using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Tag.Commands.AddTag;

namespace WebUtil.Lyrics.Application.Categories.Commands.AddCategory
{
	public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, AddCategoryResult>
	{
		private readonly ICategoryRepository _categoryRepository;

		public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<AddCategoryResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
		{
			List<Domain.Entities.Category> categories = (List<Domain.Entities.Category>)await _categoryRepository.GetAllAsync();
			if (categories.Any(category => category.CategoryCode == request.CategoryCode))
			{
				throw new Exception();
			}
			Domain.Entities.Category category = new Domain.Entities.Category()
			{
				CategoryCode = request.CategoryCode,
				CategoryName = request.CategoryName,
				Status = request.Status
			};
			int id = await _categoryRepository.AddAsync(category);
			//await _cacheManager.DeleteKey("Tag:GetAllAsync");
			return new AddCategoryResult(id);
		}
	}
}
