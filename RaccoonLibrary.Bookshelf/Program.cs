using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository;
using RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation;

using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Repositories;
using RaccoonLibrary.Bookshelf.Domain.Services;
using RaccoonLibrary.Bookshelf.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgreSqlDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection"));
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddScoped<IBookQueryService, BookQueryService>();
builder.Services.AddScoped<IAuthorQueryService, AuthorQueryService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapAuthorEndpoints();
app.MapBookEndpoints();

app.Run();