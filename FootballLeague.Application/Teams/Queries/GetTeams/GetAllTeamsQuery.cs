namespace FootballLeague.Application.Teams.Queries.GetTeams
{
  public record GetAllTeamsQuery() : IQuery<GetTeamsResult>;

  public record GetTeamsResult(IEnumerable<TeamDto> Teams);
}
