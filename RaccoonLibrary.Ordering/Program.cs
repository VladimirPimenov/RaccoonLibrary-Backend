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

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IOrderingService, OrderingService>();
builder.Services.AddScoped<IBookshelfService, BookshelfService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IBankPaymentService, MockBankService>();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapOrderEndpoints();
app.MapPaymentEndpoints();

app.Run();