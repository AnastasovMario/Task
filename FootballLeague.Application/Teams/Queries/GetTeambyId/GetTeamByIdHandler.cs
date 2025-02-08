namespace FootballLeague.Application.Teams.Queries.GetTeambyId
{
  public class GetTeamByIdHandler(IApplicationDbContext dbContext) 
    : IQueryHandler<GetTeamByIdQuery, GetTeamByIdResult>
  {
    public async Task<GetTeamByIdResult> Handle(GetTeamByIdQuery query, CancellationToken cancellationToken)
    {
      var team = await dbContext.Teams.FirstOrDefaultAsync(team => team.Id == query.Id, cancellationToken);
      if (team == null)
        throw new TeamNotFoundException(query.Id);

      var teamDto = new TeamDto(team.Id, team.Name);

      return new GetTeamByIdResult(teamDto);
    }
  }
}
