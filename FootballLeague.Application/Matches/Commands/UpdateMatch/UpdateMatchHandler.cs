﻿using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;
using FootballLeague.Application.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FootballLeague.Application.Matches.Commands.UpdateMatch
{
  public class UpdateMatchHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateMatchCommand, UpdateMatchResult>
  {
    public async Task<UpdateMatchResult> Handle(UpdateMatchCommand command, CancellationToken cancellationToken)
    {
      var match = await dbContext.Matches.FindAsync(command.Id);
      if (match == null)
        throw new NotFoundException($"Match with ID {command.Id} not found");

      match.HomeScore = command.Match.HomeScore;
      match.HomeTeamId = command.Match.HomeTeamId;
      match.AwayScore = command.Match.AwayScore;
      match.AwayTeamId = command.Match.AwayTeamId;
      match.DatePlayed = command.Match.DatePlayed;

      await dbContext.SaveChangesAsync(cancellationToken);


      return new UpdateMatchResult(true);
    }
  }
}
