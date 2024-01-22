using Mapster;
using WebUtil.Lyrics.Application.Categories.Queries.GetAllCategories;
using WebUtil.Lyrics.Application.Tags.Queries.GetAllTags;
using WebUtil.Lyrics.Contracts.Category.GetAllCategory;
using WebUtil.Lyrics.Contracts.Tag.GetAllTags;

namespace WebUtil.Lyrics.Api.Mapping
{
	public class GetCategoryMappingConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<GetAllCategoriesResult, GetAllCategoriesResponse>()
				.Map(dest => dest.CategoryList, src => src.categoryList);
		}
	}
}
