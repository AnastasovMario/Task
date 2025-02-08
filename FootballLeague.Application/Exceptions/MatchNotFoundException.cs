using BuildingBlocks.Exceptions;

namespace FootballLeague.Application.Exceptions
{
  public class MatchNotFoundException(int id) : NotFoundException("Match", id)
  {
  }
}
