using RaccoonLibrary.Authentification.Domain.DTO;

namespace RaccoonLibrary.Authentification.Domain.Contracts
{
	/// <summary>
	/// Интерфейс для аутентификации пользователей.
	/// Определяет методы для работы с аутентификацией пользователей.
	/// </summary>
	public interface IAuthentificationService
	{
		/// <summary>
		/// Регистрирует нового пользователя.
		/// </summary>
		/// <param name="registerRequest">Данные для регистрации пользователя.</param>
		/// <returns>DTO зарегистрированного пользователя.</returns>
		public Task<UserDto> RegisterAsync(UserRegisterRequest registerRequest);

		/// <summary>
		/// Выполняет вход пользователя в систему.
		/// </summary>
		/// <param name="loginRequest">Данные для входа пользователя.</param>
		/// <returns>JWT токен в случае успешного входа.</returns>
		public Task<string> LoginAsync(UserLoginRequest loginRequest);
	}
}
