using BookLand.Web.Core.ViewModels.Authors;
using BookLand.Web.Core.ViewModels.Categories;

namespace BookLand.Web.Core.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Categories
        CreateMap<Category, CategoryViewModel>();
        CreateMap<CategoryFormViewModel, Category>().ReverseMap();

        // Authors
        CreateMap<Author, AuthorViewModel>();
    }
}
