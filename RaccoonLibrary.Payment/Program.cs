using Microsoft.EntityFrameworkCore;
using RaccoonLibrary.Payment.DataAccess.PostgreSQL;
using RaccoonLibrary.Payment.DataAccess.PostgreSqlRepository.Implementation;
using RaccoonLibrary.Payment.Domain.Contracts;
using RaccoonLibrary.Payment.Domain.Repositories;
using RaccoonLibrary.Payment.Domain.Services;
using RaccoonLibrary.Payment.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<PostgreSqlDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection")));

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IBankPaymentService, MockBankService>();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapPaymentEndpoints();

app.Run();

