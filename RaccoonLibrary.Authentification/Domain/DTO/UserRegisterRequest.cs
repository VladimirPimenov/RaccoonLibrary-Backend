namespace RaccoonLibrary.Authentification.Domain.DTO
{
	/// <summary>
	/// Представляет запрос на регистрацию нового пользователя.
	/// </summary>
	public record UserRegisterRequest
	{
		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string Name { get; init; }

		/// <summary>
		/// Пароль пользователя.
		/// </summary>
		public string Password { get; init; }

		/// <summary>
		/// Адрес электронной почты пользователя.
		/// </summary>
		public string Email { get; init; }
	}
}
