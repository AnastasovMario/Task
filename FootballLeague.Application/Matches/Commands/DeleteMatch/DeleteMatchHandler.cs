namespace FootballLeague.Application.Matches.Commands.DeleteMatch
{
  public class DeleteMatchHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteMatchCommand, DeleteMatchResult>
  {
    public async Task<DeleteMatchResult> Handle(DeleteMatchCommand command, CancellationToken cancellationToken)
    {
      var match = await dbContext.Matches.FirstOrDefaultAsync(m => m.Id == command.Id, cancellationToken);
      if (match == null)
        throw new NotFoundException($"Match with ID {command.Id} not found");

      dbContext.Matches.Remove(match);
      await dbContext.SaveChangesAsync(cancellationToken);

      return new DeleteMatchResult(true);
    }
  }
}
