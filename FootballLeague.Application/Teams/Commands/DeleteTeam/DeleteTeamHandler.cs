namespace FootballLeague.Application.Teams.Commands.DeleteTeam
{
  public class DeleteTeamHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteTeamCommand, DeleteTeamResult>
  {
    public async Task<DeleteTeamResult> Handle(DeleteTeamCommand command, CancellationToken cancellationToken)
    {
      var team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == command.Id, cancellationToken);
      if (team == null)
        throw new TeamNotFoundException(command.Id);

      dbContext.Teams.Remove(team);
      await dbContext.SaveChangesAsync(cancellationToken);

      return new DeleteTeamResult(true);
    }
  }
}
