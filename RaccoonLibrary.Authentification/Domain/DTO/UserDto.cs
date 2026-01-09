namespace RaccoonLibrary.Authentification.Domain.DTO
{
	/// <summary>
	/// Представляет объект передачи данных (DTO) пользователя.
	/// </summary>
	public record UserDto
	{
		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string Name { get; init; }

		/// <summary>
		/// Адрес электронной почты пользователя.
		/// </summary>
		public string Email { get; init; }
	}
}
