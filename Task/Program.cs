using FootballLeague.Infrastructure;
using FootballLeague.Application;
using FootballLeague.Infrastructure.Data.Extensions.FootballLeague.Infrastructure.Data.Extensions;
using FootballLeague.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
  .AddApplicationServices(builder.Configuration)
  .AddInfrastructureServices(builder.Configuration)
  .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
  await app.InitialiseDatabaseAsync();
}

app.Run();
