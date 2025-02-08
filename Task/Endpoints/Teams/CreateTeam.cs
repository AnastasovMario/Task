using FootballLeague.Application.Dtos;
using FootballLeague.Application.Teams.Commands.CreateTeam;

namespace FootballLeague.API.Endpoints.Matches
{
  public record CreateTeamRequest(TeamDto Team);
  public record CreateTeamResponse(int Id);

  public class CreateTeam : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {

      app.MapPost("/teams", async (CreateTeamRequest request, ISender sender) =>
      {
        CreateTeamCommand command = request.Adapt<CreateTeamCommand>();

        CreateTeamResult result = await sender.Send(command);

        var response = result.Adapt<CreateTeamResponse>();

        return Results.Created($"/teams/{response.Id}", response);
      })
      .WithName("CreateTeam")
      .Produces<CreateTeamResponse>(StatusCodes.Status201Created)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .WithSummary("Create Team")
      .WithDescription("Create Team");
    }
  }
}
