namespace BookLand.Web.Core.Models;

[Index(nameof(Name), IsUnique = true)]
public class Category : BaseEntity
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

}