using FootballLeague.Application.Matches.Commands.CreateMatch;

namespace FootballLeague.API.Endpoints.Matches
{
  public record CreateMatchRequest(int HomeTeamId, int AwayTeamId, int HomeScore, int AwayScore, DateTime DatePlayed);
  public record CreateMatchResponse(int Id);

  public class CreateMatch : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      app.MapPost("/matches", async (CreateMatchRequest request, ISender sender) =>
      {
        CreateMatchCommand command = request.Adapt<CreateMatchCommand>();

        CreateMatchResult result = await sender.Send(command);

        CreateMatchResponse response = result.Adapt<CreateMatchResponse>();

        return Results.Created($"/matches/{response.Id}", response);
      })
      .WithName("CreateMatch")
      .Produces<CreateMatchResponse>(StatusCodes.Status201Created)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .WithSummary("Create Match")
      .WithDescription("Create Match");
    }
  }
}
