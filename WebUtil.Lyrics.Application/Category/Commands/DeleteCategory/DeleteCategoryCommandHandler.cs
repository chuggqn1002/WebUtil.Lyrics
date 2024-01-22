using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtil.Lyrics.Application.Common.Interfaces.Persistence;
using WebUtil.Lyrics.Application.Tag.Commands.DeleteTag;

namespace WebUtil.Lyrics.Application.Categories.Commands.DeleteCategory
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResult>
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly ISongCategoryRepository _songCategoryRepository;

		public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, ISongCategoryRepository songCategoryRepository)
		{
			_categoryRepository = categoryRepository;
			_songCategoryRepository = songCategoryRepository;
		}

		public async Task<DeleteCategoryResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			var songcategories = await _songCategoryRepository.GetAllAsync();
			if (songcategories.Any(sc => sc.CategoryCode == request.categorycode))
			{
				throw new Exception();
			}
			var count = await _categoryRepository.DeleteByCodeAsync(request.categorycode);
			return new DeleteCategoryResult(count);
		}
	}
}
