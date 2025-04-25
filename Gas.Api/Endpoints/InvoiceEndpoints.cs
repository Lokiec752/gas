using Gas.Api.Data;
using Gas.Api.Dto;
using Gas.Api.Entity;
using Gas.Api.Mapping;
using Gas.Api.Services;
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
      await ctx.Invoices.AddAsync(invoice);
      await ctx.SaveChangesAsync();

      return Results.CreatedAtRoute(InvoiceEndpointName, new { id = invoice.Id }, invoice.ToDto());
    });

    group.MapPost("/register", async (InvoiceRegistrationDto registration, GasCalculationsDbContext ctx, BillingService billingService) =>
    {
      // Start an explicit transaction
      using var transaction = await ctx.Database.BeginTransactionAsync();

      try
      {
        // create and add an invoice entity
        Invoice invoice = registration.Invoice.ToEntity();
        await ctx.Invoices.AddAsync(invoice);

        // create and add readings entities
        GasMeterReading newReadings = registration.Reading.ToEntity();
        await ctx.Readings.AddAsync(newReadings);

        // Save to generate IDs for invoice and readings
        await ctx.SaveChangesAsync();

        // compute the previous readings date
        DateOnly previousDate = invoice.Date.AddMonths(-1);

        // find previous reading - use FirstOrDefaultAsync to avoid issues with multiple readings
        GasMeterReading? previousReading = await ctx.Readings
          .Where(reading => reading.Date.Year == previousDate.Year && reading.Date.Month == previousDate.Month)
          .FirstOrDefaultAsync();

        if (previousReading == null)
        {
          return Results.Problem("Couldn't find the previous reading");
        }

        // get bills from the service
        // TODO: user id's are hardcoded, TBC
        UserBillResult bills = billingService.CreateUserBill(invoice, newReadings, previousReading, 1, 2);

        await ctx.UserBills.AddRangeAsync(bills.PrimaryBill, bills.SecondaryBill);

        // Save the bills separately
        await ctx.SaveChangesAsync();

        // Commit the transaction if everything succeeds
        await transaction.CommitAsync();

        return Results.Ok(bills);
      }
      catch (Exception ex)
      {
        // Rollback the transaction if any exception occurs
        await transaction.RollbackAsync();
        return Results.Problem($"Transaction failed and was rolled back. Error: {ex.Message}");
      }
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
