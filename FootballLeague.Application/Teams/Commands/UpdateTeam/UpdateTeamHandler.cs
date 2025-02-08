using BuildingBlocks.CQRS;
using FootballLeague.Application.Data;
using FootballLeague.Application.Exceptions;

namespace FootballLeague.Application.Teams.Commands.UpdateTeam
{
  public class UpdateTeamHandler(IApplicationDbContext dbContext)
      : ICommandHandler<UpdateTeamCommand, UpdateTeamResult>
  {
    public async Task<UpdateTeamResult> Handle(UpdateTeamCommand command, CancellationToken cancellationToken)
    {
      var team = await dbContext.Teams.FindAsync(command.Id);
      if (team == null)
        throw new MatchNotFoundException(command.Id);

      team.Name = command.Team.Name;
      await dbContext.SaveChangesAsync(cancellationToken);

      return new UpdateTeamResult(true);
    }
  }

}
