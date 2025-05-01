namespace Dating.Profile.QueryService.Infrastructure.Data;

public class ApplicationDBContext : DbContext
{
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserPreferences> UsersPreferences { get; set; }

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
            entity.HasOne(u => u.Preferences)
                .WithOne(p => p.UserProfile)
                .HasForeignKey<UserPreferences>(p => p.UserId);

            entity.ToTable(t => t.HasCheckConstraint("CK_Valid_Birthday", "\"Birthday\" >= '1900-01-01' AND \"Birthday\" <= current_date"));
        });

        builder.HasPostgresExtension("postgis");


        builder.Entity<UserPreferences>(entity =>
        {
            entity.HasKey(p => p.UserId);

            entity.ToTable(t => t.HasCheckConstraint("CK_SearchRadius_Greater_Zero", "\"SearchRadius\" > 0"));
        });


        //builder.Entity<City>().Property(b => b.Location).HasColumnType("geography (point)");
    }
}