using RaccoonLibrary.ReaderLibrary.Domain.DTO;
using RaccoonLibrary.ReaderLibrary.Domain.Entities;

namespace RaccoonLibrary.ReaderLibrary.Domain.Contracts
{
	/// <summary>
	/// Определяет методы для управления библиотекой читателя.
	/// </summary>
	public interface ILibraryService
	{
		/// <summary>
		/// Возвращает список книг в библиотеке читателя.
		/// </summary>
		/// <param name="readerId">Идентификатор читателя.</param>
		/// <returns>Список книг читателя.</returns>
		public Task<List<Book>> GetReaderBooksAsync(int readerId);

		/// <summary>
		/// Добавляет книгу в библиотеку читателя.
		/// </summary>
		/// <param name="request">Запрос на добавление книги.</param>
		/// <returns>Объект ReaderBook, представляющий добавленную книгу.</returns>
		public Task<ReaderBook> AddBookToReaderAsync(BookAddingRequest request);

		/// <summary>
		/// Проверяет, находится ли книга в библиотеке читателя.
		/// </summary>
		/// <param name="bookId">Идентификатор книги.</param>
		/// <param name="readerId">Идентификатор читателя.</param>
		/// <returns>True, если книга находится в библиотеке читателя, иначе False.</returns>
		public Task<bool> IsBookInReaderLibraryAsync(int bookId, int readerId);
	}
}
