using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.ReaderLibrary.Domain.Contracts;
using RaccoonLibrary.ReaderLibrary.Domain.DTO;

namespace RaccoonLibrary.ReaderLibrary.Endpoints
{
	public static class ReaderBookEndpoints
	{
		public static void MapReaderBookEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("{readerId}/books", GetReaderBooksAsync);
			app.MapPost("", AddBookToReaderAsync);
		}

		private static async Task<IResult> GetReaderBooksAsync(
			[FromRoute] int readerId,
			[FromServices] IReaderBooksService booksService)
		{
			var books = await booksService.GetReaderBooksAsync(readerId);

			return Results.Ok(books);
		}

		private static async Task<IResult> AddBookToReaderAsync(
			[FromBody] BookAddingRequest request,
			[FromServices] IReaderBooksService booksService)
		{
			var addedBook = await booksService.AddBookToReaderAsync(request);

			return addedBook == null ? Results.BadRequest() : Results.Ok(addedBook);
		}
	}
}
