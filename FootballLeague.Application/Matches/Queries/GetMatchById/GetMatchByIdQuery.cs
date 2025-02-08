using BuildingBlocks.CQRS;
using FootballLeague.Application.Dtos;

namespace FootballLeague.Application.Matches.Queries.GetMatchById
{
  public record GetMatchByIdQuery(int Id) : IQuery<GetMatchByIdResult>;

  public record GetMatchByIdResult(MatchDto match);
}
