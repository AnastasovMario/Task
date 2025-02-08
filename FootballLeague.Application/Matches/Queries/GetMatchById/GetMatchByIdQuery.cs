namespace FootballLeague.Application.Matches.Queries.GetMatchById
{
  public record GetMatchByIdQuery(int Id) : IQuery<GetMatchByIdResult>;

  public record GetMatchByIdResult(FootballMatchDto Match);
}
