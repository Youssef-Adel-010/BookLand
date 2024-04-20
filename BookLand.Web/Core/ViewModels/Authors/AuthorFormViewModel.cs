namespace BookLand.Web.Core.ViewModels.Categories;

public class AuthorFormViewModel
{
    public int Id { get; set; }

    [MaxLength(20, ErrorMessage = "The maximum length is 100 characters")]
    [Remote("IsAllowedRecord", "Authors", AdditionalFields = nameof(Id), ErrorMessage = "This name is already exists")]
    public string Name { get; set; } = null!;
}
