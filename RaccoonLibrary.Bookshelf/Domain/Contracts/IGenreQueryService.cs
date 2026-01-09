using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	/// <summary>
	/// Интерфейс для работы с жанрами.
	/// </summary>
	public interface IGenreQueryService
	{
		/// <summary>
		/// Создает новый жанр.
		/// </summary>
		/// <param name="genre">Объект жанра для создания.</param>
		/// <returns>Созданный жанр.</returns>
		public Task<Genre> CreateGenreAsync(Genre genre);

		/// <summary>
		/// Удаляет жанр по его идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор жанра для удаления.</param>
		/// <returns>Идентификатор удаленного жанра, или null, если жанр не найден.</returns>
		public Task<int?> RemoveGenreAsync(int id);
	}
}
