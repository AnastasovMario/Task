using FootballLeague.Application.Matches.Commands.DeleteMatch;

namespace FootballLeague.API.Endpoints.Matches
{
  public record DeleteMatchResponse(bool IsSuccess);
  public class DeleteMatch : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      app.MapDelete("/matches/{id}", async (int Id, ISender sender) =>
      {
        var result = await sender.Send(new DeleteMatchCommand(Id));

        var response = result.Adapt<DeleteMatchResponse>();

        return Results.Ok(response);
      })
      .WithName("DeleteMatch")
      .Produces<DeleteMatchResponse>(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .ProducesProblem(StatusCodes.Status404NotFound)
      .WithSummary("Delete Match")
      .WithDescription("Delete Match");
    }
  }
}
