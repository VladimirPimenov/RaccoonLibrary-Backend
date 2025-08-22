using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Bookshelf.Domain.Repositories;
using RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository;
using RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation;

using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostgreSqlDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection"));
});

builder.Services.AddScoped<ISearchRepository, SearchRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IBookQueryService, BookQueryService>();
builder.Services.AddScoped<IAuthorQueryService, AuthorQueryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();