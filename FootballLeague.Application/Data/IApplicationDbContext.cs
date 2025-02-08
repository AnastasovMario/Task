using FootballLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Application.Data
{
  public interface IApplicationDbContext
  {
    DbSet<Team> Teams { get; set; }
    DbSet<Match> Matches { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

  }
}
