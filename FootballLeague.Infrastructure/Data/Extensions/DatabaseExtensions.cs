using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Infrastructure.Data.Extensions
{

  namespace FootballLeague.Infrastructure.Data.Extensions
  {
    public static class DatabaseExtensions
    {
      public static async Task InitialiseDatabaseAsync(this WebApplication app)
      {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();
        await SeedAsync(context);
      }

      private static async Task SeedAsync(ApplicationDbContext context)
      {
        await SeedTeamsAsync(context);
        await SeedMatchesAsync(context);
      }

      private static async Task SeedTeamsAsync(ApplicationDbContext context)
      {
        if (!await context.Teams.AnyAsync())
        {
          await context.Teams.AddRangeAsync(InitialData.Teams);
          await context.SaveChangesAsync();
        }
      }

      private static async Task SeedMatchesAsync(ApplicationDbContext context)
      {
        if (!await context.Matches.AnyAsync())
        {
          await context.Matches.AddRangeAsync(InitialData.Matches);
          await context.SaveChangesAsync();
        }
      }
    }
  }

}
