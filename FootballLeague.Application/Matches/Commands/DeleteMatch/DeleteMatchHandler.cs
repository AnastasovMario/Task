using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;
using FootballLeague.Application.Data;

namespace FootballLeague.Application.Matches.Commands.DeleteMatch
{
  public class DeleteMatchHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteMatchCommand, DeleteMatchResult>
  {
    public async Task<DeleteMatchResult> Handle(DeleteMatchCommand command, CancellationToken cancellationToken)
    {
      var match = await dbContext.Matches.FindAsync(command.Id);
      if (match == null)
        throw new NotFoundException($"Match with ID {command.Id} not found");

      dbContext.Matches.Remove(match);
      await dbContext.SaveChangesAsync(cancellationToken);

      return new DeleteMatchResult(true);
    }
  }
}
