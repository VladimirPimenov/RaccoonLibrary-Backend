namespace RaccoonLibrary.Authentification.Domain.DTO
{
	/// <summary>
	/// Представляет запрос на вход пользователя.
	/// </summary>
	public record UserLoginRequest
	{
		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string Name { get; init; }

		/// <summary>
		/// Пароль пользователя.
		/// </summary>
		public string Password { get; init; }
	}
}
