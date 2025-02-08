
namespace FootballLeague.Application.Matches.Commands.CreateMatch
{
  public class CreateMatchHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateMatchCommand, CreateMatchResult>
    {
        public async Task<CreateMatchResult> Handle(CreateMatchCommand command, CancellationToken cancellationToken)
        {
            var homeTeam = await dbContext.Teams.FirstOrDefaultAsync(m => m.Id == command.HomeTeamId, cancellationToken);
            var awayTeam = await dbContext.Teams.FirstOrDefaultAsync(m => m.Id == command.AwayTeamId, cancellationToken);

            var match = new FootballMatch
            {
                HomeTeamId = command.HomeTeamId,
                AwayTeamId = command.AwayTeamId,
                HomeScore = command.HomeScore,
                AwayScore = command.AwayScore,
                DatePlayed = command.DatePlayed
            };

            UpdateTeamStats(homeTeam, awayTeam, match.HomeScore, match.AwayScore);

            dbContext.Matches.Add(match);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateMatchResult(match.Id);
        }

        private void UpdateTeamStats(Team homeTeam, Team awayTeam, int homeScore, int awayScore)
        {
            homeTeam.MatchesPlayed++;
            awayTeam.MatchesPlayed++;

            if (homeScore > awayScore)
            {
                homeTeam.Wins++;
                homeTeam.Points += 3;
                awayTeam.Losses++;
            }
            else if (homeScore < awayScore)
            {
                awayTeam.Wins++;
                awayTeam.Points += 3;
                homeTeam.Losses++;
            }
            else
            {
                homeTeam.Draws++;
                awayTeam.Draws++;
                homeTeam.Points++;
                awayTeam.Points++;
            }
        }
    }
}
