using BuildingBlocks.CQRS;
using FootballLeague.Application.Data;
using FootballLeague.Domain.Entities;

namespace FootballLeague.Application.Teams.Commands.CreateTeam
{
  public class CreateTeamHandler(IApplicationDbContext dbContext)
      : ICommandHandler<CreateTeamCommand, CreateTeamResult>
  {
    public async Task<CreateTeamResult> Handle(CreateTeamCommand command, CancellationToken cancellationToken)
    {
      var team = new Team { Name = command.Team.Name };

      dbContext.Teams.Add(team);
      await dbContext.SaveChangesAsync(cancellationToken);

      return new CreateTeamResult(team.Id);
    }
  }

}
