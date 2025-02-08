using FootballLeague.Domain.Abstraction;

namespace FootballLeague.Domain.Entities
{
  public class FootballMatch : Entity
  {
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public DateTime DatePlayed { get; set; }

    public Team HomeTeam { get; set; } = null!;
    public Team AwayTeam { get; set; } = null!;
  }
}
