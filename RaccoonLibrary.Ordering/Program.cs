using Microsoft.EntityFrameworkCore;
using RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository;
using RaccoonLibrary.Ordering.DataAccess.PostgreSqlRepository.Implementation;
using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.Repositories;
using RaccoonLibrary.Ordering.Domain.Services;
using RaccoonLibrary.Ordering.Endpoints;
using RaccoonLibrary.ReaderLibrary;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgreSqlDbContext>(options => 
	options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL:DefaultConnection")));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IOrderingService, OrderingService>();
builder.Services.AddScoped<IBookshelfService, BookshelfService>();
builder.Services.AddScoped<ICustomerLibraryService, CustomerLibraryService>();
builder.Services.AddScoped<IOrderPaymentService, OrderPaymentService>();
builder.Services.AddScoped<IPaymentApiClient, PaymentApiClient>();

builder.Services.AddTokenAuthentification(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapOrderEndpoints();
app.MapPaymentEndpoints();

app.UseAuthentication();
app.UseAuthorization();

app.Run();