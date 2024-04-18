namespace BookLand.Web.Core.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Categories Mapping
        CreateMap<Category, CategoryViewModel>();
        CreateMap<CategoryFormViewModel, Category>().ReverseMap();
    }
}
