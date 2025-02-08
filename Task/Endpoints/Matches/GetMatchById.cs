using FootballLeague.Application.Matches.Queries.GetMatchById;

namespace FootballLeague.API.Endpoints.Matches
{
  public record GetMatchByIdResponse(FootballMatchDto Match);

  public class GetMatchById : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      app.MapGet("/matches/{Id}", async (int Id, ISender sender) =>
      {
        var result = await sender.Send(new GetMatchByIdQuery(Id));

        var response = result.Adapt<GetMatchByIdResponse>();

        return Results.Ok(response);
      })
      .WithName("GetMatchById")
      .Produces<GetMatchByIdResponse>(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .ProducesProblem(StatusCodes.Status404NotFound)
      .WithSummary("Get Match By Id")
      .WithDescription("Get Match By Id");
    }
  }
}
