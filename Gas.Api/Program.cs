using Gas.Api.Data;
using Gas.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GasCalculationsDb");
builder.Services.AddSqlite<GasCalculationsDbContext>(connString);

var app = builder.Build();

app.MapInvoiceEndpoints();
app.MapUserEndpoints();
app.MapUserBillEndpoints();
app.MapGasMeterReadingsEndpoints();

await app.MigrateDbAsync();

app.Run();
