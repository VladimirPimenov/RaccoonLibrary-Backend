using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Endpoints
{
	/// <summary>
	/// Предоставляет API для управления книгами, их авторами и жанрами.
	/// </summary>
	public static class BookEndpoints
	{
		/// <summary>
		/// Регистрирует конечные точки API для книг.
		/// </summary>
		public static void MapBookEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/book/{bookId}", GetBookAsync);
			app.MapPost("/book", CreateBookAsync);
			app.MapDelete("/book/{bookId}", RemoveBookAsync);

			app.MapPost("/book/author", AddAuthorToBookAsync);
			app.MapDelete("/book/author", RemoveAuthorFromBookAsync);

			app.MapPost("/book/genre", AddGenreToBookAsync);
			app.MapDelete("/book/genre", RemoveGenreFromBookAsync);
		}

		/// <summary>
		/// Получает информацию о книге по ее идентификатору.
		/// </summary>
		/// <param name="bookId">Идентификатор книги.</param>
		/// <param name="bookService">Сервис для работы с книгами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Возвращает объект книги.</description></item>
		/// <item><term>404 Not Found</term><description> Книга с указанным идентификатором не найдена.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> GetBookAsync(
			[FromRoute] int bookId,
			[FromServices] IBookQueryService bookService)
		{
			var book = await bookService.GetBookAsync(bookId);

			return book == null ? Results.NotFound() : Results.Ok(book);
		}

		/// <summary>
		/// Создает новую книгу.
		/// </summary>
		/// <param name="book">Данные новой книги.</param>
		/// <param name="bookService">Сервис для работы с книгами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Возвращает созданный объект книги.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные книги.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> CreateBookAsync(
			[FromBody] Book book,
			[FromServices] IBookQueryService bookService
			)
		{
			Book newBook = await bookService.CreateBookAsync(book);

			return newBook == null ? Results.BadRequest() : Results.Ok(book);
		}

		/// <summary>
		/// Удаляет книгу по ее идентификатору.
		/// </summary>
		/// <param name="bookId">Идентификатор книги для удаления.</param>
		/// <param name="bookService">Сервис для работы с книгами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Возвращает идентификатор удаленной книги.</description></item>
		/// <item><term>400 Bad Request</term><description> Книга с указанным идентификатором не найдена.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> RemoveBookAsync(
			[FromRoute] int bookId,
			[FromServices] IBookQueryService bookService)
		{
			int? removedBookId = await bookService.RemoveBookAsync(bookId);

			return removedBookId == null ? Results.BadRequest() : Results.Ok(removedBookId);
		}

		/// <summary>
		/// Добавляет автора к книге.
		/// </summary>
		/// <param name="bookAuthor">Объект, связывающий книгу и автора.</param>
		/// <param name="bookService">Сервис для работы с книгами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Успешно добавлено.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> AddAuthorToBookAsync(
			[FromBody] BookAuthor bookAuthor,
			[FromServices] IBookQueryService bookService)
		{
			Book updatedBook = await bookService.AddAuthorToBookAsync(bookAuthor);

			return updatedBook == null ? Results.BadRequest() : Results.Ok();
		}

		/// <summary>
		/// Открепляет автора от книги.
		/// </summary>
		/// <param name="bookAuthor">Объект, связывающий книгу и автора.</param>
		/// <param name="bookService">Сервис для работы с книгами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Успешно удалено.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> RemoveAuthorFromBookAsync(
			[FromBody] BookAuthor bookAuthor,
			[FromServices] IBookQueryService bookService)
		{
			Book updatedBook = await bookService.RemoveAuthorFromBookAsync(bookAuthor);

			return updatedBook == null ? Results.BadRequest() : Results.Ok();
		}

		/// <summary>
		/// Добавляет жанр к книге.
		/// </summary>
		/// <param name="bookGenre">Объект, связывающий книгу и жанр.</param>
		/// <param name="bookService">Сервис для работы с книгами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Успешно добавлено.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> AddGenreToBookAsync(
			[FromBody] BookGenre bookGenre,
			[FromServices] IBookQueryService bookService)
		{
			Book updatedBook = await bookService.AddGenreToBookAsync(bookGenre);

			return updatedBook == null ? Results.BadRequest() : Results.Ok();
		}

		/// <summary>
		/// Открепляет жанр от книги.
		/// </summary>
		/// <param name="bookGenre">Объект, связывающий книгу и жанр.</param>
		/// <param name="bookService">Сервис для работы с книгами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Успешно удалено.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> RemoveGenreFromBookAsync(
			[FromBody] BookGenre bookGenre,
			[FromServices] IBookQueryService bookService)
		{
			Book updatedBook = await bookService.RemoveGenreFromBookAsync(bookGenre);

			return updatedBook == null ? Results.BadRequest() : Results.Ok();
		}
	}
}
