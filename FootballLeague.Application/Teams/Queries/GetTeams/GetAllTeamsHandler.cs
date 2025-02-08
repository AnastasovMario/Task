using BuildingBlocks.CQRS;
using FootballLeague.Application.Data;
using FootballLeague.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Application.Teams.Queries.GetTeams
{
  public class GetAllTeamsHandler(IApplicationDbContext dbContext)
      : IQueryHandler<GetAllTeamsQuery, GetTeamsResult>
  {
    public async Task<GetTeamsResult> Handle(GetAllTeamsQuery query, CancellationToken cancellationToken)
    {
      var teams = await dbContext.Teams
          .Select(t => new TeamDto(t.Id, t.Name, t.Points))
          .OrderByDescending(t => t.Points)
          .ThenBy(t => t.Name)
          .ToListAsync(cancellationToken);

      return new GetTeamsResult(teams);
    }
  }
}
