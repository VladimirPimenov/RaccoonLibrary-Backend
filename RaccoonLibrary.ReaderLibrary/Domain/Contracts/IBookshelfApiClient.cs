using RaccoonLibrary.ReaderLibrary.Domain.Entities;

namespace RaccoonLibrary.ReaderLibrary.Domain.Contracts
{
	/// <summary>
	/// Определяет методы для взаимодействия с API сервиса Bookshelf.
	/// </summary>
	public interface IBookshelfApiClient
	{
		/// <summary>
		/// Получает книгу по ее идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор книги.</param>
		/// <returns>Объект книги или null, если книга не найдена.</returns>
		public Task<Book> GetBookByIdAsync(int id);
	}
}
