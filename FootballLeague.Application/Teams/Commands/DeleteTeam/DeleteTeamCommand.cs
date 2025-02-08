namespace FootballLeague.Application.Teams.Commands.DeleteTeam
{
  public record DeleteTeamCommand(int Id) : ICommand<DeleteTeamResult>;

  public record DeleteTeamResult(bool IsSucess);

  public class DeleteCommandValidator : AbstractValidator<DeleteTeamCommand>
  {
    public DeleteCommandValidator()
    {
      RuleFor(x => x.Id).NotEmpty().WithMessage("TeamId is required");
    }
  }
}
