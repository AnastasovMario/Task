using FootballLeague.Application.Matches.Queries.GetAllMatches;

namespace FootballLeague.API.Endpoints.Matches
{
  public record GetMatchesResponse(List<FootballMatchDto> Matches);
  public class GetMatches : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      app.MapGet("/matches", async ( ISender sender) =>
      {
        var result = await sender.Send(new GetAllMatchesQuery());

        var response = result.Adapt<GetMatchesResponse>();

        return Results.Ok(response);
      })
      .WithName("GetMatches")
      .Produces<GetMatchesResponse>(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .ProducesProblem(StatusCodes.Status404NotFound)
      .WithSummary("Get Matches")
      .WithDescription("Get Matches");
    }
  }
}
