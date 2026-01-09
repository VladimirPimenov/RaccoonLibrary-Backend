namespace RaccoonLibrary.Authentification.Domain.Entities
{
	/// <summary>
	/// Представляет пользователя в системе аутентификации.
	/// </summary>
	public class User
	{
		/// <summary>
		/// Уникальный идентификатор пользователя.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Имя пользователя.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Хэшированный пароль пользователя.
		/// </summary>
		public string Password { get; set; }
		
		/// <summary>
		/// Адрес электронной почты пользователя.
		/// </summary>
		public string Email { get; set; }
	}
}
