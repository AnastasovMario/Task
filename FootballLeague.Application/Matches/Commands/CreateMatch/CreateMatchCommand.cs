using BuildingBlocks.CQRS;
using FluentValidation;
using FootballLeague.Application.Dtos;

namespace FootballLeague.Application.Matches.Commands.CreateMatch
{
    public record CreateMatchCommand(MatchDto Match) : ICommand<CreateMatchResult>;

    public record CreateMatchResult(int Id);

    public class CreateMatchCommandValidator : AbstractValidator<CreateMatchCommand>
    {
        public CreateMatchCommandValidator()
        {
            RuleFor(x => x.Match.HomeTeamId).NotEqual(x => x.Match.AwayTeamId)
                .WithMessage("Home and Away teams must be different.");

            RuleFor(x => x.Match.DatePlayed).LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Match date cannot be in the future.");
        }
    }
}
