namespace Dating.Profile.QueryService.Infrastructure.Data;

public class ApplicationDBContext : DbContext
{
    public DbSet<UserProfile> UserProfiles { get; set; }

    public ApplicationDBContext(DbContextOptions options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Birthday)
                  .IsRequired();

            entity.Property(e => e.SearchRadius);
        });

    }
}