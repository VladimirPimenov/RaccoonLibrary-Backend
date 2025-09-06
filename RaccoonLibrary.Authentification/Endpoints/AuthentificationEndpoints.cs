using RaccoonLibrary.Authentification.Domain.DTO;


using RaccoonLibrary.Authentification.Domain.Contracts;

namespace RaccoonLibrary.Authentification.Endpoints
{
    public static class AuthentificationEndpoints
    {
        public static void MapAuthentificationEndpoints(this IEndpointRouteBuilder app)
        {
			app.MapPost("register", RegisterAsync);
			app.MapPost("login", LoginAsync);
        }

		private static async Task<IResult> RegisterAsync(
			UserRegisterRequest request,
			IAuthentificationService authService)
		{
			var registeredUser = await authService.RegisterAsync(request);

			return registeredUser == null ? Results.BadRequest() : Results.Ok(registeredUser);
		}

		private static async Task<IResult> LoginAsync(
			UserLoginRequest request,
			IAuthentificationService authService,
			HttpContext httpContext)
		{
			var token = await authService.LoginAsync(request);

			if (token == null)
				return Results.Unauthorized();

			httpContext.Response.Cookies.Append("token", token);

			return Results.Ok(token);
		}
	}
}