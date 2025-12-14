using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository;
using RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository.Implementation;

using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.Repositories;
using RaccoonLibrary.Ordering.Domain.Services;

using RaccoonLibrary.Ordering.Endpoints;

using RaccoonLibrary.Ordering.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgreSqlDbContext>(options => 
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection")));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IOrderingService, OrderingService>();
builder.Services.AddScoped<IBookshelfApiClient, BookshelfApiClient>();
builder.Services.AddScoped<ICustomerLibraryApiClient, CustomerLibraryApiClient>();
builder.Services.AddScoped<IOrderPaymentService, OrderPaymentService>();
builder.Services.AddScoped<IPaymentApiClient, MockBankService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.MapOrderEndpoints();
app.MapPaymentEndpoints();

app.Run();