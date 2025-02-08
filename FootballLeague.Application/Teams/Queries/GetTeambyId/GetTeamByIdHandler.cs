using BuildingBlocks.CQRS;
using FootballLeague.Application.Data;
using FootballLeague.Application.Dtos;
using FootballLeague.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Application.Teams.Queries.GetTeambyId
{
  public class GetTeamByIdHandler(IApplicationDbContext dbContext) 
    : IQueryHandler<GetTeamByIdQuery, GetTeamByIdResult>
  {
    public async Task<GetTeamByIdResult> Handle(GetTeamByIdQuery query, CancellationToken cancellationToken)
    {
      var team = await dbContext.Teams.FirstOrDefaultAsync(team => team.Id == query.Id);
      if (team == null)
        throw new TeamNotFoundException(query.Id);

      var teamDto = new TeamDto(team.Id, team.Name);

      return new GetTeamByIdResult(teamDto);
    }
  }
}
