using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using System.Text;

using RaccoonLibrary.Authentification.Domain.Contracts;
using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Domain.Services
{
	public class JwtTokenProvider(
		IConfiguration config) 
		: ITokenProvider
	{
		public string GenerateAccessToken(User user)
		{
			var claims = new List<Claim>
			{
				new Claim("userId", user.UserId.ToString())
			};

			var key = config.GetValue<string>("JwtConfiguration:Secretkey");
				
			var credentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), 
				SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				claims: claims,
				signingCredentials: credentials,
				expires: DateTime.Now.AddHours(24));

			var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

			return tokenValue;
		}
	}
}
