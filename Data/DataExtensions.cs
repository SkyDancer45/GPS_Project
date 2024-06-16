﻿using Microsoft.EntityFrameworkCore;

namespace GPS.Api.Data;

public static class DataExtensions
{


  public static void MigrateDb(this WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<GpsContext>();

    dbContext.Database.Migrate();
  }
}
