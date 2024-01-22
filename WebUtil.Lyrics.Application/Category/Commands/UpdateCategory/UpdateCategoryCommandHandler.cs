using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Tag.Commands.UpdateTag;

namespace WebUtil.Lyrics.Application.Categories.Commands.UpdateCategory
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResult>
	{
		private readonly ICategoryRepository _categoryRepository;

		public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<UpdateCategoryResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
		{
			Domain.Entities.Category? c = await _categoryRepository.GetByCodeAsync(request.CategoryCode);
			if (c == null)
			{
				throw new Exception("invalid TagCode");
			}
			Domain.Entities.Category category = new Domain.Entities.Category()
			{
				CategoryCode = request.CategoryCode,
				CategoryName = request.CategoryName,
				Status = request.Status
			};
			int r = await _categoryRepository.UpdateAsync(category);
			return new UpdateCategoryResult(r);
		}
	}
}
