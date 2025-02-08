using BuildingBlocks.CQRS;
using FootballLeague.Application.Dtos;

namespace FootballLeague.Application.Matches.Queries.GetAllMatches
{
  public record GetAllMatchesQuery() : IQuery<GetAllMatchesResult>;

  public record GetAllMatchesResult(List<MatchDto> matches);
}
