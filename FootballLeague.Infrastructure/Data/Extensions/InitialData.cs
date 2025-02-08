namespace FootballLeague.Infrastructure.Data.Extensions
{
  public static class InitialData
  {
    public static List<Team> Teams => new()
        {
            new Team { Name = "Team A", Points = 0, MatchesPlayed = 1, Wins = 0, Draws = 0, Losses = 1 },
            new Team { Name = "Team B", Points = 3, MatchesPlayed = 1, Wins = 1, Draws = 0, Losses = 0 },
            new Team { Name = "Team C", Points = 1, MatchesPlayed = 1, Wins = 0, Draws = 1, Losses = 0 },
            new Team { Name = "Team D", Points = 1, MatchesPlayed = 1, Wins = 0, Draws = 1, Losses = 0 }
        };

    public static List<Match> Matches => new()
        {
            new Match
            {
                HomeTeamId = 1, AwayTeamId = 2, HomeScore = 1, AwayScore = 2, DatePlayed = DateTime.UtcNow
            },
            new Match
            {
                HomeTeamId = 3, AwayTeamId = 4, HomeScore = 3, AwayScore = 3, DatePlayed = DateTime.UtcNow
            }
        };
  }
}
