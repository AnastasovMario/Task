namespace FootballLeague.Application.Matches.Commands.CreateMatch
{
  public record CreateMatchCommand(int HomeTeamId, int AwayTeamId, int HomeScore, int AwayScore, DateTime DatePlayed) : ICommand<CreateMatchResult>;

  public record CreateMatchResult(int Id);

  public class CreateMatchCommandValidator : AbstractValidator<CreateMatchCommand>
  {
    public CreateMatchCommandValidator()
    {
      RuleFor(x => x.HomeTeamId)
          .NotEqual(x => x.AwayTeamId)
          .WithMessage("Home and Away teams must be different.");

      RuleFor(x => x.DatePlayed)
          .LessThanOrEqualTo(DateTime.UtcNow)
          .WithMessage("Match date cannot be in the future.");
    }
  }
}
