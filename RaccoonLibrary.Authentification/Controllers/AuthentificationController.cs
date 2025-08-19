using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Authentification.Domain.DTO;
using RaccoonLibrary.Authentification.Domain.Contracts;

namespace RaccoonLibrary.Authentification.Controllers
{
	[Route("user")]
	[ApiController]
	public class AuthentificationController(
		IAuthentificationService authService)
		: ControllerBase
	{
		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsync(UserRegisterRequest request)
		{
			var registeredUser = await authService.RegisterAsync(request);

			return registeredUser == null ? BadRequest() : Ok(registeredUser);
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync(UserLoginRequest request)
		{
			var token = await authService.LoginAsync(request);

			if (token == null)
				return Unauthorized();

			return Ok(token);
		}
	}
}
