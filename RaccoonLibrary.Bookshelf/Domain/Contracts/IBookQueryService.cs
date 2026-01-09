using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	/// <summary>
	/// Интерфейс для работы с книгами.
	/// </summary>
	public interface IBookQueryService
	{
		/// <summary>
		/// Получает книгу по ее идентификатору.
		/// </summary>
		/// <param name="bookId">Идентификатор книги.</param>
		/// <returns>Найденная книга или null, если книга не найдена.</returns>
		public Task<Book> GetBookAsync(int bookId);

		/// <summary>
		/// Создает новую книгу.
		/// </summary>
		/// <param name="book">Объект книги для создания.</param>
		/// <returns>Созданная книга.</returns>
		public Task<Book> CreateBookAsync(Book book);

		/// <summary>
		/// Удаляет книгу по ее идентификатору.
		/// </summary>
		/// <param name="bookId">Идентификатор книги для удаления.</param>
		/// <returns>Идентификатор удаленной книги, или null, если книга не найдена.</returns>
		public Task<int?> RemoveBookAsync(int bookId);

		/// <summary>
		/// Добавляет автора к книге.
		/// </summary>
		/// <param name="bookAuthor">Объект, связывающий книгу и автора.</param>
		/// <returns>Обновленный объект книги.</returns>
		public Task<Book> AddAuthorToBookAsync(BookAuthor bookAuthor);

		/// <summary>
		/// Открепляет автора от книги.
		/// </summary>
		/// <param name="bookAuthor">Объект, связывающий книгу и автора.</param>
		/// <returns>Обновленный объект книги.</returns>
		public Task<Book> RemoveAuthorFromBookAsync(BookAuthor bookAuthor);
		
		/// <summary>
		/// Добавляет жанр к книге.
		/// </summary>
		/// <param name="bookGenre">Объект, связывающий книгу и жанр.</param>
		/// <returns>Обновленный объект книги.</returns>
		public Task<Book> AddGenreToBookAsync(BookGenre bookGenre);

		/// <summary>
		/// Убирает жанр книги.
		/// </summary>
		/// <param name="bookGenre">Объект, связывающий книгу и жанр.
		/// <returns>Обновленный объект книги.</returns>
		public Task<Book> RemoveGenreFromBookAsync(BookGenre bookGenre);
	}
}
