using Gas.Api.Data;
using Gas.Api.Dto.User;
using Gas.Api.Entity;
using Gas.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Gas.Api.Endpoints;

public static class UserEndpoints
{
  public static RouteGroupBuilder MapUserEndpoints(this WebApplication app)
  {
    const string UserEndpointName = "GetUser";

    var builder = app.MapGroup("/users").WithParameterValidation();

    builder.MapGet("/", async (GasCalculationsDbContext ctx) =>
     await ctx.Users.Select(user => user.ToDto()).AsNoTracking().ToListAsync()
    );

    builder.MapGet("/{id}", async (int id, GasCalculationsDbContext ctx) =>
    {
      var user = await ctx.Users.FindAsync(id);
      if (user == null)
      {
        return Results.NotFound();
      }
      return Results.Ok(user.ToDto());
    }).WithName(UserEndpointName);

    builder.MapPost("/", async (CreateUserDto user, GasCalculationsDbContext ctx) =>
    {
      User newUser = user.ToEntity();
      ctx.Users.Add(newUser);
      await ctx.SaveChangesAsync();

      return Results.CreatedAtRoute(UserEndpointName, new { id = newUser.Id }, newUser.ToDto());
    });

    builder.MapPut("/{id}", async (int id, UpdateUserDto newUser, GasCalculationsDbContext ctx) =>
    {
      var existingUser = await ctx.Users.FindAsync(id);
      if (existingUser == null)
      {
        return Results.NotFound();
      }
      User user = newUser.ToEntity(id);
      ctx.Entry(existingUser).CurrentValues.SetValues(newUser);
      await ctx.SaveChangesAsync();

      return Results.NoContent();
    });

    builder.MapDelete("/{id}", async (int id, GasCalculationsDbContext ctx) =>
    {
      await ctx.Users.Where(user => user.Id == id).ExecuteDeleteAsync();
      return Results.NoContent();
    });

    return builder;
  }
}
