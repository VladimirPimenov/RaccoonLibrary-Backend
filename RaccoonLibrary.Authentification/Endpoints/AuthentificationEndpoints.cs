using RaccoonLibrary.Authentification.Domain.DTO;

using RaccoonLibrary.Authentification.Domain.Contracts;

namespace RaccoonLibrary.Authentification.Endpoints
{
    /// <summary>
    /// Предоставляет API для аутентификации пользователей.
    /// </summary>
    public static class AuthentificationEndpoints
    {
        /// <summary>
        /// Регистрирует конечные точки аутентификации в приложении.
        /// </summary>
        public static void MapAuthentificationEndpoints(this IEndpointRouteBuilder app)
        {
			app.MapPost("register", RegisterAsync);
			app.MapPost("login", LoginAsync);
			app.MapPost("logout", LogoutAsync);
        }

		/// <summary>
		/// Обрабатывает запрос на регистрацию нового пользователя.
		/// </summary>
		/// <param name="request">Данные для регистрации пользователя.</param>
		/// <param name="authService">Сервис аутентификации.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Успешная регистрация.</description></item>
		/// <item><term>400 Bad Request</term><description> Ошибка в запросе.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> RegisterAsync(
			UserRegisterRequest request,
			IAuthentificationService authService)
		{
			var registeredUser = await authService.RegisterAsync(request);

			return registeredUser == null ? Results.BadRequest() : Results.Ok(registeredUser);
		}

		/// <summary>
		/// Обрабатывает запрос на вход пользователя в систему.
		/// </summary>
		/// <param name="request">Данные для входа пользователя.</param>
		/// <param name="authService">Сервис аутентификации.</param>
		/// <param name="httpContext">Контекст HTTP-запроса.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Успешный вход (токен добавлен в куки).</description></item>
		/// <item><term>401 Unauthorized</term><description> Неверные учетные данные пользователя.</description></item>
		/// </list>
		/// </returns>
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
		
		/// <summary>
		/// Обрабатывает запрос на выход пользователя из системы.
		/// </summary>
		/// <param name="httpContext">Контекст HTTP-запроса.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Успешный выход из системы (токен удален из куки).</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> LogoutAsync(
			HttpContext httpContext
		)
		{
			httpContext.Response.Cookies.Delete("token");

			return Results.Ok();
		}
	}
}