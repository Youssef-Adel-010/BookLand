namespace BookLand.Web.Core.Models;

public class Author : BaseEntity
{
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public DateTime LastUpdatedOn { get; set; }
}
