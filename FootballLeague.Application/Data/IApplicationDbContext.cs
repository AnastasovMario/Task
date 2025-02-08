namespace FootballLeague.Application.Data
{
  public interface IApplicationDbContext
  {
    DbSet<Team> Teams { get; set; }
    DbSet<FootballMatch> Matches { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

  }
}
