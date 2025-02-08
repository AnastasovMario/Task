namespace FootballLeague.Application.Teams.Queries.GetTeambyId
{
  public record GetTeamByIdQuery(int Id) : IQuery<GetTeamByIdResult>;

  public record GetTeamByIdResult(TeamDto Team);
}
