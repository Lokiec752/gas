using Gas.Api.Data;
using Gas.Api.Dto;
using Gas.Api.Entity;
using Gas.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Gas.Api.Endpoints;

public static class InvoiceEndpoints
{

  const string InvoiceEndpointName = "GetInvoice";

  public static RouteGroupBuilder MapInvoiceEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("/invoices").WithParameterValidation();

    group.MapGet("/", async (GasCalculationsDbContext ctx) =>
    {
      return await ctx.Invoices.Select(invoice => invoice.ToDto()).AsNoTracking().ToListAsync();
    });

    group.MapGet("/{id}", async (int id, GasCalculationsDbContext ctx) =>
    {
      var invoice = await ctx.Invoices.FindAsync(id);
      if (invoice == null)
      {
        return Results.NotFound();
      }
      return Results.Ok(invoice.ToDto());
    }).WithName(InvoiceEndpointName);

    group.MapPost("/", async (CreateInvoiceDto newInvoice, GasCalculationsDbContext ctx) =>
    {
      Invoice invoice = newInvoice.ToEntity();
      ctx.Invoices.Add(invoice);
      await ctx.SaveChangesAsync();

      return Results.CreatedAtRoute(InvoiceEndpointName, new { id = invoice.Id }, invoice.ToDto());
    });

    group.MapPut("/{id}", async (int id, UpdateInvoiceDto updatedInvoice, GasCalculationsDbContext ctx) =>
    {
      var existingInvoice = await ctx.Invoices.FindAsync(id);
      if (existingInvoice == null)
      {
        return Results.NotFound();
      }
      Invoice invoice = updatedInvoice.ToEntity(existingInvoice.Id);
      ctx.Entry(existingInvoice).CurrentValues.SetValues(invoice);
      await ctx.SaveChangesAsync();

      return Results.NoContent();
    });

    group.MapDelete("/{id}", async (int id, GasCalculationsDbContext ctx) =>
    {
      await ctx.Invoices.Where(invoice => invoice.Id == id).ExecuteDeleteAsync();
      return Results.NoContent();
    });

    return group;
  }

}
