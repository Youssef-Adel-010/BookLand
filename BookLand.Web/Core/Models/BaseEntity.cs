namespace BookLand.Web.Core.Models;

[Index(nameof(Name), IsUnique = true)]
public class BaseEntity
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }
}