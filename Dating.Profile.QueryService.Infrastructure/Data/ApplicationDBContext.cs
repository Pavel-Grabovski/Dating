namespace Dating.Profile.QueryService.Infrastructure.Data;

public class ApplicationDBContext : DbContext
{
    public DbSet<UserProfile> UserProfiles { get; set; }

    public ApplicationDBContext(DbContextOptions options)
        : base(options) 
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresEnum<Gender>();
        builder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable(t => t.HasCheckConstraint("CK_SearchRadius_Greater_Zero", "\"SearchRadius\" > 0"));
            entity.ToTable(t => t.HasCheckConstraint("CK_Valid_Birthday", "\"Birthday\" >= '1900-01-01' AND \"Birthday\" <= current_date"));
        });

        builder.HasPostgresExtension("postgis");

        //builder.Entity<City>().Property(b => b.Location).HasColumnType("geography (point)");
    }
}