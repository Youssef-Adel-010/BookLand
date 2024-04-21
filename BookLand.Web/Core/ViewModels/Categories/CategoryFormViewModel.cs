using BookLand.Web.Core.Constants;

namespace BookLand.Web.Core.ViewModels.Categories;

public class CategoryFormViewModel
{
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = Errors.MaxLengthError)]
    [Display(Name = "Category")]
    [Remote("IsAllowedRecord", "Categories", AdditionalFields = nameof(Id), ErrorMessage = Errors.UniqueError)]
    public string Name { get; set; } = null!;
}
