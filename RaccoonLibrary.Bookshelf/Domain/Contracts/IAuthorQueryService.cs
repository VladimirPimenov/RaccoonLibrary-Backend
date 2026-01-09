using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	/// <summary>
	/// Интерфейс для работы с авторами.
	/// </summary>
	public interface IAuthorQueryService
	{
		/// <summary>
		/// Получает автора по его идентификатору.
		/// </summary>
		/// <param name="authorId">Идентификатор автора.</param>
		/// <returns>Найденный автор или null, если автор не найден.</returns>
		public Task<Author> GetAuthorAsync(int authorId);

		/// <summary>
		/// Создает нового автора.
		/// </summary>
		/// <param name="author">Объект автора для создания.</param>
		/// <returns>Созданный автор.</returns>
		public Task<Author> CreateAuthorAsync(Author author);

		/// <summary>
		/// Удаляет автора по его идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор автора для удаления.</param>
		/// <returns>Идентификатор удаленного автора, или null, если автор не найден.</returns>
		public Task<int?> RemoveAuthorAsync(int id);
	}
}
