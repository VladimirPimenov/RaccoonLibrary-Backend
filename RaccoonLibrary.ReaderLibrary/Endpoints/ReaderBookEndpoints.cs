using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.ReaderLibrary.Domain.Contracts;
using RaccoonLibrary.ReaderLibrary.Domain.DTO;

namespace RaccoonLibrary.ReaderLibrary.Endpoints
{
	/// <summary>
	/// Предоставляет API для управления библиотекой читателя.
	/// </summary>
	public static class ReaderBookEndpoints
	{
		/// <summary>
		/// Регистрирует конечные точки API для библиотеки читателя.
		/// </summary>
		public static void MapReaderBookEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("{readerId}/books", GetReaderBooksAsync);
			app.MapGet("{readerId}/books/{bookId}", IsBookInReaderLibrary);
			app.MapPost("", AddBookToReaderAsync);
		}

		/// <summary>
		/// Получает список книг в библиотеке читателя.
		/// </summary>
		/// <param name="readerId">Идентификатор читателя.</param>
		/// <param name="booksService">Сервис для работы с библиотекой читателя.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Возвращает список книг читателя.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> GetReaderBooksAsync(
			[FromRoute] int readerId,
			[FromServices] ILibraryService booksService)
		{
			var books = await booksService.GetReaderBooksAsync(readerId);

			return Results.Ok(books);
		}

		/// <summary>
		/// Добавляет книгу в библиотеку читателя.
		/// </summary>
		/// <param name="request">Запрос на добавление книги.</param>
		/// <param name="booksService">Сервис для работы с библиотекой читателя.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Книга успешно добавлена, возвращает объект ReaderBook.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные в запросе или ошибка при добавлении книги.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> AddBookToReaderAsync(
			[FromBody] BookAddingRequest request,
			[FromServices] ILibraryService booksService)
		{
			var addedBook = await booksService.AddBookToReaderAsync(request);

			return addedBook == null ? Results.BadRequest() : Results.Ok(addedBook);
		}

		/// <summary>
		/// Проверяет, находится ли книга в библиотеке читателя.
		/// </summary>
		/// <param name="readerId">Идентификатор читателя.</param>
		/// <param name="bookId">Идентификатор книги.</param>
		/// <param name="booksService">Сервис для работы с библиотекой читателя.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Книга находится в библиотеке читателя.</description></item>
		/// <item><term>404 Not Found</term><description> Книга не найдена в библиотеке читателя.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> IsBookInReaderLibrary(
			[FromRoute] int readerId, 
			[FromRoute] int bookId, 
			[FromServices] ILibraryService booksService)
		{
			bool isBookInLibrary = await booksService.IsBookInReaderLibraryAsync(bookId, readerId);

			return isBookInLibrary ? Results.Ok() : Results.NotFound();
		}
	}
}
