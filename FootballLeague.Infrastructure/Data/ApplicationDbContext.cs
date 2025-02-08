using FootballLeague.Application.Data;
using FootballLeague.Domain.Abstraction;
using FootballLeague.Domain.Entities;
using System.Reflection;

namespace FootballLeague.Infrastructure.Data
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
  {
    public DbSet<Team> Teams { get; set; }
    public DbSet<Match> Matches { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
      //Applying all of the configurations of type IEntityTypeConfiguration
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
