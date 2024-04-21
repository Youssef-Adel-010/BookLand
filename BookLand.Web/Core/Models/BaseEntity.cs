namespace BookLand.Web.Core.Models;

public class BaseEntity
{
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public DateTime? LastUpdatedOn { get; set; } = null;

    public bool IsDeleted { get; set; }
}