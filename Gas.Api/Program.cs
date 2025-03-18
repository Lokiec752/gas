using Gas.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GasCalculationsDb");
builder.Services.AddSqlite<GasCalculationsDbContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.MigrateDbAsync();

app.Run();
