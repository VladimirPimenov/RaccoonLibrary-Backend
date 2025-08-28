using Microsoft.EntityFrameworkCore;
using RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository;
using RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository.Implementation;
using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.Repositories;
using RaccoonLibrary.Ordering.Domain.Services;
using RaccoonLibrary.Ordering.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<PostgreSqlDbContext>(options => 
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection")));

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapOrderEndpoints();
app.MapPaymentEndpoints();

app.Run();