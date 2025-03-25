using Gas.Api.Data;
using Gas.Api.Dto.UserBill;
using Gas.Api.Entity;
using Gas.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Gas.Api.Endpoints;

public static class UserBillEndpoints
{
  const string UserBillEndpointName = "GetUserEndpoint";
  public static RouteGroupBuilder MapUserBillEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("/user-bill").WithParameterValidation();

    group.MapGet("/", async (GasCalculationsDbContext ctx) =>
    {
      return await ctx.UserBills.Select(bill => bill.toDto()).AsNoTracking().ToListAsync();
    });

    group.MapGet("/{id}", async (int id, GasCalculationsDbContext ctx) =>
    {
      var bill = await ctx.UserBills.FindAsync(id);
      if (bill == null)
      {
        return Results.NotFound();
      }

      return Results.Ok(bill);
    }).WithDisplayName(UserBillEndpointName);

    group.MapPost("/{id}", async (int id, CreateUserBillDto newBill, GasCalculationsDbContext ctx) =>
    {
      var existingBill = await ctx.UserBills.FindAsync(id);
      if (existingBill == null)
      {
        return Results.NotFound();
      }
      UserBill bill = newBill.toEntity();
      ctx.UserBills.Add(bill);
      await ctx.SaveChangesAsync();

      return Results.CreatedAtRoute(UserBillEndpointName, new { id = bill.Id }, bill.toDto());
    });

    group.MapPut("/{id}", async (int id, UpdateUserBillDto newBill, GasCalculationsDbContext ctx) =>
    {
      var existingBill = await ctx.UserBills.FindAsync(id);
      if (existingBill == null)
      {
        return Results.NotFound();
      }
      ctx.Entry(existingBill).CurrentValues.SetValues(newBill);
      await ctx.SaveChangesAsync();

      return Results.NoContent();
    });

    group.MapDelete("/{id}", async (int id, GasCalculationsDbContext ctx) =>
    {
      await ctx.UserBills.Where(bill => bill.Id == id).ExecuteDeleteAsync();

      return Results.NoContent();
    });

    return group;
  }

}
