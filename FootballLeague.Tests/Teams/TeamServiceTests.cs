using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Xunit;

namespace FootballLeague.Tests.Teams
{
  public class TeamServiceTests
  {
    private readonly Mock<IApplicationDbContext> _dbContextMock;

    public FootballLeagueTests()
    {
      _dbContextMock = new Mock<IApplicationDbContext>;
    }

    // TEAMS TESTS
    [Fact]
    public async Task GetTeamById_ShouldReturn_Team()
    {
      var team = new Team { Id = 1, Name = "Team A", Points = 10 };
      _dbContextMock.Setup(db => db.Teams.FindAsync(1)).ReturnsAsync(team);

      var result = await _dbContextMock.Object.Teams.FindAsync(1);

      Assert.NotNull(result);
      Assert.Equal("Team A", result.Name);
    }

    [Fact]
    public async Task GetAllTeams_ShouldReturn_AllTeams()
    {
      var teams = new List<Team> { new Team { Id = 1, Name = "Team A" }, new Team { Id = 2, Name = "Team B" } };
      _dbContextMock.Setup(db => db.Teams.ToListAsync(It.IsAny<CancellationToken>())).ReturnsAsync(teams);

      var result = await _dbContextMock.Object.Teams.ToListAsync(CancellationToken.None);

      Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task CreateTeam_ShouldAdd_Team()
    {
      var team = new Team { Id = 3, Name = "Team C" };
      _dbContextMock.Setup(db => db.Teams.AddAsync(team, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
      _dbContextMock.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

      await _dbContextMock.Object.Teams.AddAsync(team, CancellationToken.None);
      await _dbContextMock.Object.SaveChangesAsync(CancellationToken.None);

      _dbContextMock.Verify(db => db.Teams.AddAsync(team, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateTeam_ShouldModify_Team()
    {
      var team = new Team { Id = 1, Name = "Team A" };
      _dbContextMock.Setup(db => db.Teams.FindAsync(1)).ReturnsAsync(team);

      team.Name = "Updated Team A";
      await _dbContextMock.Object.SaveChangesAsync(CancellationToken.None);

      Assert.Equal("Updated Team A", team.Name);
    }

    [Fact]
    public async Task DeleteTeam_ShouldRemove_Team()
    {
      var team = new Team { Id = 1, Name = "Team A" };
      _dbContextMock.Setup(db => db.Teams.FindAsync(1)).ReturnsAsync(team);
      _dbContextMock.Setup(db => db.Teams.Remove(team));
      _dbContextMock.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

      _dbContextMock.Object.Teams.Remove(team);
      await _dbContextMock.Object.SaveChangesAsync(CancellationToken.None);

      _dbContextMock.Verify(db => db.Teams.Remove(team), Times.Once);
    }
  }
}
