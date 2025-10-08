using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Authentification.Storage;
using RaccoonLibrary.Authentification.Domain.Repositories;
using RaccoonLibrary.Authentification.Storage.RepositoryImplementation;

using RaccoonLibrary.Authentification.Domain.Contracts;
using RaccoonLibrary.Authentification.Domain.Services;
using RaccoonLibrary.Authentification.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection")));

builder.Services.AddScoped<IAuthentificationRepository, AuthentificationRepository>();

builder.Services.AddScoped<IAuthentificationService, AuthentificationService>();
builder.Services.AddScoped<ITokenProvider, JwtTokenProvider>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapAuthentificationEndpoints();

app.Run();