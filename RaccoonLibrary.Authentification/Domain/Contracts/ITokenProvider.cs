using RaccoonLibrary.Authentification.Domain.Entities;

namespace RaccoonLibrary.Authentification.Domain.Contracts
{
	/// <summary>
	/// Интерфейс для генерации токенов аутентификации.
	/// </summary>
	public interface ITokenProvider
	{
		/// <summary>
		/// Генерирует токен JWT для указанного пользователя.
		/// </summary>
		/// <param name="user">Пользователь, для которого генерируется токен.</param>
		/// <returns>Строка, представляющая токен.</returns>
		public string GenerateAccessToken(User user);
	}
}
