namespace FootballLeague.Application.Teams.Commands.UpdateTeam
{
  public record UpdateTeamCommand(int Id, TeamDto Team) : ICommand<UpdateTeamResult>;

  public record UpdateTeamResult(bool IsSuccess);

  public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
  {
    public UpdateTeamCommandValidator()
    {
      RuleFor(x => x.Team.Name).NotEmpty().WithMessage("Team name is required");
    }
  }
}
