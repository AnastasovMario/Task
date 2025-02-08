namespace FootballLeague.Application.Matches.Queries.GetMatchById
{
  public class GetMatchByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetMatchByIdQuery, GetMatchByIdResult>
  {
    public async Task<GetMatchByIdResult> Handle(GetMatchByIdQuery query, CancellationToken cancellationToken)
    {
      var match = await dbContext.Matches.FirstOrDefaultAsync(m => m.Id == query.Id, cancellationToken);
      if (match == null)
        throw new MatchNotFoundException(query.Id);

      var matchDto = new FootballMatchDto(match.Id, match.HomeTeamId, match.AwayTeamId, match.HomeScore, match.AwayScore, match.DatePlayed);
      return new GetMatchByIdResult(matchDto);
    }
  }
}
