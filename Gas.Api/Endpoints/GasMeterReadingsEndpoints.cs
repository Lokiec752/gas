using Gas.Api.Data;
using Gas.Api.Dto.GasMeterReading;
using Gas.Api.Entity;
using Gas.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Gas.Api.Endpoints;

public static class GasMeterReadingsEndpoints
{
  public static RouteGroupBuilder MapGasMeterReadingsEndpoints(this WebApplication app)
  {
    const string ReadingsEndpointName = "GetGasMeterReadings";

    var group = app.MapGroup("/readings").WithParameterValidation();

    group.MapGet("/", async (GasCalculationsDbContext ctx) =>
      await ctx.Readings.Select(reading => reading.ToDto()).AsNoTracking().ToListAsync()
    );

    group.MapGet("/{id}", async (int id, GasCalculationsDbContext ctx) =>
    {
      var existingReading = await ctx.Readings.FindAsync(id);
      if (existingReading == null)
      {
        return Results.NotFound();
      }
      return Results.Ok(existingReading.ToDto());
    }).WithName(ReadingsEndpointName);

    group.MapPost("/{id}", async (int id, CreateGasMeterReadingDto newReading, GasCalculationsDbContext ctx) =>
    {
      GasMeterReading reading = newReading.ToEntity();
      ctx.Readings.Add(reading);
      await ctx.SaveChangesAsync();

      return Results.CreatedAtRoute(ReadingsEndpointName, new { id = reading.Id }, reading.ToDto());
    });

    group.MapPut("/{id}", async (int id, UpdateGasMeterReadingDto newReading, GasCalculationsDbContext ctx) =>
    {
      var existingReading = await ctx.Readings.FindAsync(id);
      if (existingReading == null)
      {
        return Results.NotFound();
      }
      GasMeterReading reading = newReading.ToEntity(id);
      ctx.Entry(existingReading).CurrentValues.SetValues(reading);
      await ctx.SaveChangesAsync();

      return Results.NoContent();
    });

    group.MapDelete("/{id}", async (int id, GasCalculationsDbContext ctx) =>
    {
      await ctx.Readings.Where(reading => reading.Id == id).ExecuteDeleteAsync();
      return Results.NoContent();
    });

    return group;
  }
}
