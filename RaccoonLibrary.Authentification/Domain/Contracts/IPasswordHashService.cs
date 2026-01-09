namespace RaccoonLibrary.Authentification.Domain.Contracts
{
	/// <summary>
	/// Интерфейс для хеширования и проверки паролей.
	/// </summary>
	public interface IPasswordHashService
	{
		/// <summary>
		/// Хеширует пароль.
		/// </summary>
		/// <param name="password">Пароль для хеширования.</param>
		/// <returns>Хешированный пароль.</returns>
		public string HashPassword(string password);

		/// <summary>
		/// Проверяет, соответствует ли пароль хешированному паролю.
		/// </summary>
		/// <param name="password">Пароль для проверки.</param>
		/// <param name="hashedPassword">Хешированный пароль для сравнения.</param>
		/// <returns>True, если пароли совпадают, иначе False.</returns>
		public bool VerifyPassword(string password, string hashedPassword);
	}
}
