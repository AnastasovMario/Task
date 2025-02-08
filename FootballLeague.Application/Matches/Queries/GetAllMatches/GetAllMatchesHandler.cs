namespace FootballLeague.Application.Matches.Queries.GetAllMatches
{
  public class GetAllMatchesHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetAllMatchesQuery, GetAllMatchesResult>
  {
    public async Task<GetAllMatchesResult> Handle(GetAllMatchesQuery request, CancellationToken cancellationToken)
    {
      return new GetAllMatchesResult(await dbContext.Matches
          .Select(m => new FootballMatchDto(m.Id, m.HomeTeamId, m.AwayTeamId, m.HomeScore, m.AwayScore, m.DatePlayed))
          .ToListAsync(cancellationToken));
    }
  }
}
