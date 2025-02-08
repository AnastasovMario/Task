using FootballLeague.Application.Dtos;
using FootballLeague.Application.Teams.Queries.GetTeambyId;

namespace FootballLeague.API.Endpoints.Matches
{
  public record GetTeamByIdResponse(IEnumerable<TeamDto> Teams);

  public class GetTeamById : ICarterModule
  {
    public void AddRoutes(IEndpointRouteBuilder app)
    {
      app.MapGet("/teams/{Id}", async (int Id, ISender sender) =>
      {
        var result = await sender.Send(new GetTeamByIdQuery(Id));

        var response = result.Adapt<GetTeamByIdResponse>();

        return Results.Ok(response);
      })
      .WithName("GetTeamById")
      .Produces<GetTeamByIdResponse>(StatusCodes.Status200OK)
      .ProducesProblem(StatusCodes.Status400BadRequest)
      .ProducesProblem(StatusCodes.Status404NotFound)
      .WithSummary("Get Team By Id")
      .WithDescription("Get Team By Id");
    }
  }
}
