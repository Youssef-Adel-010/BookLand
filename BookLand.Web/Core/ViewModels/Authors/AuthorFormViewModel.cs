using BookLand.Web.Core.Constants;

namespace BookLand.Web.Core.ViewModels.Categories;

public class AuthorFormViewModel
{
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = Errors.MaxLengthError)]
    [Display(Name = "Author")]
    [Remote("IsAllowedRecord", "Authors", AdditionalFields = nameof(Id), ErrorMessage = Errors.UniqueError)]
    public string Name { get; set; } = null!;
}
