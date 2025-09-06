using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RaccoonLibrary.ReaderLibrary
{
	public static class ServiceCollectionExtensions
	{
		public static void AddTokenAuthentification(
			this IServiceCollection services,
			IConfiguration config)
		{
			var key = config.GetValue<string>("JwtConfiguration:Secretkey");

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
				{
					options.TokenValidationParameters = new()
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = false,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
					};

					options.Events = new JwtBearerEvents
					{
						OnMessageReceived = context =>
						{
							context.Token = context.Request.Cookies["token"];

							return Task.CompletedTask;
						}
					};
				});
		}
	}
}
