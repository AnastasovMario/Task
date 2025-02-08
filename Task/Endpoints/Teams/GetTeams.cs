//using FootballLeague.Application.Dtos;
//using FootballLeague.Application.Teams.Queries.GetTeams;

//namespace FootballLeague.API.Endpoints.Matches
//{
//  public record GetTeamsResponse(IEnumerable<TeamDto> Teams);
//  public class GetTeam : ICarterModule
//  {
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//      app.MapGet("/teams", async ([AsParameters] IEnumerable<TeamDto> request, ISender sender) =>
//      {
//        var result = await sender.Send(new GetAllTeamsQuery());

//        var response = result.Adapt<GetTeamsResponse>();

//        return Results.Ok(response);
//      })
//      .WithName("GetTeams")
//      .Produces<GetTeamsResponse>(StatusCodes.Status200OK)
//      .ProducesProblem(StatusCodes.Status400BadRequest)
//      .ProducesProblem(StatusCodes.Status404NotFound)
//      .WithSummary("Get Teams")
//      .WithDescription("Get Teams");
//    }
//  }
//}
