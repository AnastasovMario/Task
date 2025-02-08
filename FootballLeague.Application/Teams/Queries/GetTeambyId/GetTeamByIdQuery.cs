using BuildingBlocks.CQRS;
using FootballLeague.Application.Dtos;
using FootballLeague.Domain.Entities;

namespace FootballLeague.Application.Teams.Queries.GetTeambyId
{
  public record GetTeamByIdQuery(int Id) : IQuery<GetTeamByIdResult>;

  public record GetTeamByIdResult(TeamDto team);
}
