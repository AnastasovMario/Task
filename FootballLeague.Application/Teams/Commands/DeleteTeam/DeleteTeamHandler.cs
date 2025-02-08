using BuildingBlocks.CQRS;
using FootballLeague.Application.Data;
using FootballLeague.Application.Exceptions;

namespace FootballLeague.Application.Teams.Commands.DeleteTeam
{
  public class DeleteTeamHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteTeamCommand, DeleteTeamResult>
  {
    public async Task<DeleteTeamResult> Handle(DeleteTeamCommand command, CancellationToken cancellationToken)
    {
      var team = await dbContext.Teams.FindAsync(command.Id);
      if (team == null)
        throw new TeamNotFoundException(command.Id);

      dbContext.Teams.Remove(team);
      await dbContext.SaveChangesAsync(cancellationToken);

      return new DeleteTeamResult(true);
    }
  }
}
