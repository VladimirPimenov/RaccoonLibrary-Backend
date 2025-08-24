using Microsoft.EntityFrameworkCore;

using Scalar.AspNetCore;

using RaccoonLibrary.ReaderLibrary.DataAccess.PostgreSqlRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PostgreSqlDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection")));

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();