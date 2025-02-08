using System.Reflection;

namespace FootballLeague.Infrastructure.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
  {
    public DbSet<Team> Teams { get; set; }
    public DbSet<FootballMatch> Matches { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      foreach (var entry in ChangeTracker.Entries<IEntity>())
      {
        if (entry.State == EntityState.Added)
        {
          entry.Entity.CreatedAt = DateTime.UtcNow;
        }

        if (entry.State == EntityState.Modified)
        {
          entry.Entity.LastModified = DateTime.UtcNow;
        }
      }

      return await base.SaveChangesAsync(cancellationToken);
    }
  }
}
