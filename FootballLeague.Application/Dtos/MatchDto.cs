namespace FootballLeague.Application.Dtos
{
  public record MatchDto(int Id, int HomeTeamId, int AwayTeamId, int HomeScore, int AwayScore, DateTime DatePlayed);

}
