using BuildingBlocks.CQRS;
using FootballLeague.Application.Data;
using FootballLeague.Domain.Entities;

namespace FootballLeague.Application.Matches.Commands.CreateMatch
{
    public class CreateMatchHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateMatchCommand, CreateMatchResult>
    {
        public async Task<CreateMatchResult> Handle(CreateMatchCommand command, CancellationToken cancellationToken)
        {
            var homeTeam = await dbContext.Teams.FindAsync(command.Match.HomeTeamId);
            var awayTeam = await dbContext.Teams.FindAsync(command.Match.AwayTeamId);

            var match = new Match
            {
                HomeTeamId = command.Match.HomeTeamId,
                AwayTeamId = command.Match.AwayTeamId,
                HomeScore = command.Match.HomeScore,
                AwayScore = command.Match.AwayScore,
                DatePlayed = command.Match.DatePlayed
            };

            // Update Team Statistics
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
