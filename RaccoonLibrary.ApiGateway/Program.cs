using Ocelot.DependencyInjection;
using Ocelot.Middleware;

using RaccoonLibrary.ApiGateway;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddJwtTokenAuthentification(builder.Configuration);
	
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();

app.Run();