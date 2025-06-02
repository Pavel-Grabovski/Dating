using Dating.Profile.Domain.Entities;

namespace Dating.Profile.QueryService.Infrastructure.Data;

public class ApplicationDBContext : DbContext
{
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserSearchFilters> UsersSearchFilters { get; set; }
    public DbSet<PremiumSubscription> PremiumSubscriptions { get; set; }

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
                .HasForeignKey<UserSearchFilters>(p => p.UserId);

            entity.HasOne(u => u.PremiumSubscription)
                .WithOne(p => p.Owner)
                .HasForeignKey<PremiumSubscription>(p => p.UserId);

            entity.ToTable(t => t.HasCheckConstraint("CK_Valid_Birthday", "\"Birthday\" >= '1900-01-01' AND \"Birthday\" <= current_date"));
            entity.ToTable(t => t.HasCheckConstraint("CK_Valid_Gender", "\"Gender\" IN ('man', 'woman')"));
        });

        builder.HasPostgresExtension("postgis");


        builder.Entity<UserSearchFilters>(entity =>
        {
            entity.HasKey(p => p.UserId);

            entity.ToTable(t => t.HasCheckConstraint("CK_SearchRadius_Greater_Zero", "\"SearchRadius\" > 0"));
        });

        builder.Entity<PremiumSubscription>(entity =>
        {
            entity.HasKey(p => p.UserId);
            entity.ToTable(t => t.HasCheckConstraint("CK_Valid_EndTime", "\"EndTime\" > NOW()"));
        });


        //builder.Entity<City>().Property(b => b.Location).HasColumnType("geography (point)");
    }
}