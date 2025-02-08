﻿using BuildingBlocks.Behaviours;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FootballLeague.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplicationServices
      (this IServiceCollection services, IConfiguration configuration)
    {
      services.AddMediatR(config =>
      {
        config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        config.AddOpenBehavior(typeof(ValidationBehavior<,>));
      });


      return services;
    }
  }
}
