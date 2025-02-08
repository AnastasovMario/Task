namespace FootballLeague.Application.Teams.Commands.CreateTeam
{
  public record CreateTeamCommand(TeamDto Team) : ICommand<CreateTeamResult>;

  public record CreateTeamResult(int Id);

  public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
  {
    public CreateTeamCommandValidator()
    {
      RuleFor(x => x.Team.Name).NotEmpty().WithMessage("Team name is required");
    }
  }

}
