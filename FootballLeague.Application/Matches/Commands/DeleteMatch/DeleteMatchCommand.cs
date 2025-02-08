using BuildingBlocks.CQRS;
using FluentValidation;

namespace FootballLeague.Application.Matches.Commands.DeleteMatch
{
  public record DeleteMatchCommand(int Id) : ICommand<DeleteMatchResult>;

  public record DeleteMatchResult(bool isSuccess);

  public class DeleteCommandValidator : AbstractValidator<DeleteMatchCommand>
  {
    public DeleteCommandValidator()
    {
      RuleFor(x => x.Id).NotEmpty().WithMessage("MatchId is required");
    }
  }
}
