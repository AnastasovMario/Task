using FootballLeague.Application.Dtos;
using FootballLeague.Application.Matches.Commands.UpdateMatch;

namespace FootballLeague.API.Endpoints.Matches
{
  public record UpdateMatchRequest(MatchDto Match);
  public record UpdateMatchResponse(bool IsSuccess);

  public class UpdateMatch : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      app.MapPut("/teams", async (UpdateMatchRequest request, ISender sender) =>
      {
        var command = request.Adapt<UpdateMatchCommand>();

        var result = await sender.Send(command);

        var response = result.Adapt<UpdateMatchResponse>();

        return Results.Ok(response);
      })
      .WithName("UpdateMatch")
      .Produces<UpdateTeamResponse>(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .WithSummary("Update Match")
      .WithDescription("Update Match");
    }
  }
}
