using Microsoft.EntityFrameworkCore;

using Scalar.AspNetCore;

using RaccoonLibrary.ReaderLibrary.DataAccess.PostgreSqlRepository;
using RaccoonLibrary.ReaderLibrary.DataAccess.PostgreSqlRepository.Implementation;
using RaccoonLibrary.ReaderLibrary.Domain.Repositories;

using RaccoonLibrary.ReaderLibrary.Domain.Contracts;
using RaccoonLibrary.ReaderLibrary.Domain.Services;

using RaccoonLibrary.ReaderLibrary.Endpoints;
using RaccoonLibrary.ReaderLibrary;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<PostgreSqlDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection")));

builder.Services.AddScoped<IReaderBooksRepository, ReaderBooksRepository>();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IReaderBooksService, ReaderBooksService>();
builder.Services.AddScoped<IBookshelfService, BookshelfService>();

builder.Services.AddTokenAuthentification(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapReaderBookEndpoints();

app.Run();