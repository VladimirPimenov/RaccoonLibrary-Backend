using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Endpoints
{
	public static class BookEndpoints
	{
		public static void MapBookEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/book/{bookId}", GetBookAsync);
		}

		private static async Task<IResult> GetBookAsync(
			[FromRoute] int bookId,
			[FromServices] IBookQueryService bookService)
		{
			var book = await bookService.GetBook(bookId);

			return book == null ? Results.NotFound() : Results.Ok(book);
		}
	}
}
