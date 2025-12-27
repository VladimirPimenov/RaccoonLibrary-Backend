using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Endpoints
{
	public static class BookEndpoints
	{
		public static void MapBookEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/book/{bookId}", GetBookAsync);
			app.MapDelete("/book/{bookId}", RemoveBookAsync);

			app.MapPost("/book/author", AddAuthorToBookAsync);
			app.MapDelete("/book/author", RemoveAuthorFromBookAsync);

			app.MapPost("/book/genre", AddGenreToBookAsync);
			app.MapDelete("/book/genre", RemoveGenreFromBookAsync);
		}

		private static async Task<IResult> GetBookAsync(
			[FromRoute] int bookId,
			[FromServices] IBookQueryService bookService)
		{
			var book = await bookService.GetBookAsync(bookId);

			return book == null ? Results.NotFound() : Results.Ok(book);
		}

		private static async Task<IResult> RemoveBookAsync(
			[FromRoute] int bookId,
			[FromServices] IBookQueryService bookService)
		{
			int? removedBookId = await bookService.RemoveBookAsync(bookId);

			return removedBookId == null ? Results.BadRequest() : Results.Ok(removedBookId);
		}

		private static async Task<IResult> AddAuthorToBookAsync(
			[FromBody] BookAuthor bookAuthor,
			[FromServices] IBookQueryService bookService)
		{
			Book updatedBook = await bookService.AddAuthorToBookAsync(bookAuthor);

			return updatedBook == null ? Results.BadRequest() : Results.Ok();
		}

		private static async Task<IResult> RemoveAuthorFromBookAsync(
			[FromBody] BookAuthor bookAuthor,
			[FromServices] IBookQueryService bookService)
		{
			Book updatedBook = await bookService.RemoveAuthorFromBookAsync(bookAuthor);

			return updatedBook == null ? Results.BadRequest() : Results.Ok();
		}

		private static async Task<IResult> AddGenreToBookAsync(
			[FromBody] BookGenre bookGenre,
			[FromServices] IBookQueryService bookService)
		{
			Book updatedBook = await bookService.AddGenreToBookAsync(bookGenre);

			return updatedBook == null ? Results.BadRequest() : Results.Ok();
		}

		private static async Task<IResult> RemoveGenreFromBookAsync(
			[FromBody] BookGenre bookGenre,
			[FromServices] IBookQueryService bookService)
		{
			Book updatedBook = await bookService.RemoveGenreFromBookAsync(bookGenre);

			return updatedBook == null ? Results.BadRequest() : Results.Ok();
		}
	}
}
