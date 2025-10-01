using Microsoft.AspNetCore.Mvc;
using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Services;

namespace RaccoonLibrary.Bookshelf.Endpoints
{
	public static class SearchEndpoints
	{
		public static void MapSearchEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/search/books", SearchBooksByQueryAsync);
			app.MapGet("/search/authors", SearchAuthorByNameAsync);
		}

		private static async Task<IResult> SearchBooksByQueryAsync(
			[FromQuery] string query,
			[FromServices] ISearchService searchService)
		{
			if (query == null)
				return Results.BadRequest();

			var books = await searchService.FindBooksByQueryAsync(query);

			return Results.Ok(books);
		}

		private static async Task<IResult> SearchAuthorByNameAsync(
			[FromQuery] string query,
			[FromServices] ISearchService searchService)
		{
			if (query == null)
				return Results.BadRequest();

			var authors = await searchService.FindAuthorsAsync(query);

			return Results.Ok(authors);
		}
	}
}
