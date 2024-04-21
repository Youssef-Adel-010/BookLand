using BookLand.Web.Core.ViewModels.Authors;
using BookLand.Web.Core.ViewModels.Books;
using BookLand.Web.Core.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookLand.Web.Core.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Categories
        CreateMap<Category, CategoryViewModel>();
        CreateMap<CategoryFormViewModel, Category>().ReverseMap();
        CreateMap<Category, SelectListItem>()
            .ForMember(dest => dest.Value, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, options => options.MapFrom(src => src.Name));

        // Authors
        CreateMap<Author, AuthorViewModel>();
        CreateMap<AuthorFormViewModel, Author>().ReverseMap();
        CreateMap<Author, SelectListItem>()
            .ForMember(dest => dest.Value, options => options.MapFrom(src => src.Id))
            .ForMember(dest => dest.Text, options => options.MapFrom(src => src.Name));

        // Books
        CreateMap<BookFormViewModel, Book>();

    }
}
