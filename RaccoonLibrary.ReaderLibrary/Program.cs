using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.ReaderLibrary.DataAccess.PostgreSqlRepository;
using RaccoonLibrary.ReaderLibrary.DataAccess.PostgreSqlRepository.Implementation;
using RaccoonLibrary.ReaderLibrary.Domain.Repositories;

using RaccoonLibrary.ReaderLibrary.Domain.Contracts;
using RaccoonLibrary.ReaderLibrary.Domain.Services;

using RaccoonLibrary.ReaderLibrary.Endpoints;
using RaccoonLibrary.ReaderLibrary;

using RaccoonLibrary.ReaderLibrary.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgreSqlDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection")));

builder.Services.AddScoped<IReaderBooksRepository, ReaderBooksRepository>();

builder.Services.AddHttpClient();

builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<IBookshelfApiClient, BookshelfApiClient>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapReaderBookEndpoints();

app.Run();