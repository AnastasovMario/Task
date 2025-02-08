namespace FootballLeague.Application.Dtos
{
  public record FootballMatchDto(int Id, int HomeTeamId, int AwayTeamId, int HomeScore, int AwayScore, DateTime DatePlayed);

}
