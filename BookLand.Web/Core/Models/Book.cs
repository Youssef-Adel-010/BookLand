namespace BookLand.Web.Core.Models;

[Index(nameof(Title), nameof(AuthorId), IsUnique = true)]
public class Book : BaseEntity
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }

    public Author Author { get; set; } = null!;

    [MaxLength(100)]
    public string Publisher { get; set; } = null!;

    public DateTime PublishedOn { get; set; }

    public string? ImageUrl { get; set; }

    [MaxLength(50)]
    public string Hall { get; set; } = null!;

    public bool IsAvailableForRental { get; set; }

    [MaxLength(500)]
    public string Description { get; set; } = null!;

    public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

}
