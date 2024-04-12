namespace BookLand.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
