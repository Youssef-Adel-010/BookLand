namespace BookLand.Web.Core.ViewModels;

public class CategoryFromViewModel
{
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = "The maximum length is 100 characters")]
    [Display(Name = "Category Name")]
    public string Name { get; set; } = null!;
}
