using BuildingBlocks.CQRS;
using FootballLeague.Application.Data;
using FootballLeague.Application.Dtos;
using FootballLeague.Application.Exceptions;

namespace FootballLeague.Application.Matches.Queries.GetMatchById
{
  public class GetMatchByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetMatchByIdQuery, GetMatchByIdResult>
  {
    public async Task<GetMatchByIdResult> Handle(GetMatchByIdQuery query, CancellationToken cancellationToken)
    {
      var match = await dbContext.Matches.FindAsync(query.Id);
      if (match == null)
        throw new MatchNotFoundException(query.Id);

      var matchDto = new MatchDto(match.Id, match.HomeTeamId, match.AwayTeamId, match.HomeScore, match.AwayScore, match.DatePlayed);
      return new GetMatchByIdResult(matchDto);
    }
  }
}
