using Microsoft.EntityFrameworkCore;

using Scalar.AspNetCore;

using RaccoonLibrary.ReaderLibrary.DataAccess.PostgreSqlRepository;
using RaccoonLibrary.ReaderLibrary.Domain.Contracts;
using RaccoonLibrary.ReaderLibrary.Domain.Services;
using RaccoonLibrary.ReaderLibrary.Domain.Repositories;
using RaccoonLibrary.ReaderLibrary.DataAccess.PostgreSqlRepository.Implementation;
using RaccoonLibrary.ReaderLibrary.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<PostgreSqlDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection")));

builder.Services.AddScoped<IReaderBooksRepository, ReaderBooksRepository>();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IReaderBooksService, ReaderBooksService>();
builder.Services.AddScoped<IBookshelfService, BookshelfService>();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapReaderBookEndpoints();

app.Run();