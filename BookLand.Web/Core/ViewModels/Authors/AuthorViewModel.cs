namespace BookLand.Web.Core.ViewModels.Authors;

public class AuthorViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public DateTime LastUpdatedOn { get; set; }
}
