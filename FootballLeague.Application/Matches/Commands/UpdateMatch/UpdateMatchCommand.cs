using BuildingBlocks.CQRS;
using FluentValidation;
using FootballLeague.Application.Dtos;

namespace FootballLeague.Application.Matches.Commands.UpdateMatch
{
  public record UpdateMatchCommand(int Id, MatchDto Match) : ICommand<UpdateMatchResult>;

  public record UpdateMatchResult(bool isSuccess);

  public class UpdateMatchCommandValidator : AbstractValidator<UpdateMatchCommand>
  {
    public UpdateMatchCommandValidator()
    {
      RuleFor(x => x.Match.HomeTeamId).NotEqual(x => x.Match.AwayTeamId)
          .WithMessage("Home and Away teams must be different.");
    }
  }
}
