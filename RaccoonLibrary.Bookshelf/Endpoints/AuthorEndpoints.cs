using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Endpoints
{
	public static class AuthorEndpoints
	{
		public static void MapAuthorEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/author/{authorId}", GetAuthorAsync);
		}

		private static async Task<IResult> GetAuthorAsync(
			[FromRoute] int authorId,
			[FromServices] IAuthorQueryService authorService)
		{
			var author = await authorService.GetAuthor(authorId);

			return author == null ? Results.NotFound() : Results.Ok(author);
		}
	}
}
