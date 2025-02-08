using FootballLeague.Domain.Abstraction;

namespace FootballLeague.Domain.Entities
{
  public class Team : Entity
  {
    public string Name { get; set; } = string.Empty;
    public int Points { get; set; } = 0;
    public int MatchesPlayed { get; set; } = 0;
    public int Wins { get; set; } = 0;
    public int Draws { get; set; } = 0;
    public int Losses { get; set; } = 0;
  }
}
