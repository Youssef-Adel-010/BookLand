using BookLand.Web.Core.Constants;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookLand.Web.Core.ViewModels.Books;

public class BookFormViewModel
{
    public int Id { get; set; }

    [MaxLength(50, ErrorMessage = Errors.MaxLengthError)]
    public string Title { get; set; } = null!;

    [Display(Name = "Author")]
    public int AuthorId { get; set; }

    public IEnumerable<SelectListItem>? Authors { get; set; }

    [MaxLength(50, ErrorMessage = Errors.MaxLengthError)]
    public string Publisher { get; set; } = null!;

    [Display(Name = "Publishing Date")]
    public DateTime PublishedOn { get; set; } = DateTime.Now;

    public IFormFile? Image { get; set; }

    [MaxLength(50, ErrorMessage = Errors.MaxLengthError)]
    public string Hall { get; set; } = null!;

    [Display(Name = "Is available for rental?")]
    public bool IsAvailableForRental { get; set; }

    [MaxLength(500, ErrorMessage = Errors.MaxLengthError)]
    public string Description { get; set; } = null!;

    public IEnumerable<SelectListItem>? Categories { get; set; }

    public IList<int> SelectedCategories { get; set; } = new List<int>();

}
