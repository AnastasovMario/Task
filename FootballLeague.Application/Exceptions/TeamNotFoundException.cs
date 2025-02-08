using BuildingBlocks.Exceptions;

namespace FootballLeague.Application.Exceptions
{
    public class TeamNotFoundException(int id) : NotFoundException("Team", id)
    {
    }
}
