using Gas.Api.Data;
using Gas.Api.Endpoints;
using Gas.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GasCalculationsDb");
builder.Services.AddSqlite<GasCalculationsDbContext>(connString);

// Register BillingService
builder.Services.AddScoped<BillingService>();

var app = builder.Build();

app.MapInvoiceEndpoints();
app.MapUserEndpoints();
app.MapUserBillEndpoints();
app.MapGasMeterReadingsEndpoints();

await app.MigrateDbAsync();

app.Run();
