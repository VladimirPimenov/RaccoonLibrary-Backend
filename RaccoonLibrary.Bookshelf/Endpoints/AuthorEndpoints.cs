using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Endpoints
{
	public static class AuthorEndpoints
	{
		public static void MapAuthorEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/author/{authorId}", GetAuthorAsync);
			app.MapPost("/author", CreateAuthorAsync);
			app.MapDelete("/author/{authorId}", RemoveAuthorAsync);
		}

		private static async Task<IResult> GetAuthorAsync(
			[FromRoute] int authorId,
			[FromServices] IAuthorQueryService authorService)
		{
			var author = await authorService.GetAuthorAsync(authorId);

			return author == null ? Results.NotFound() : Results.Ok(author);
		}

		private static async Task<IResult> CreateAuthorAsync(
			[FromBody] Author author,
			[FromServices] IAuthorQueryService authorService)
		{
			var newAuthor = await authorService.CreateAuthorAsync(author);

			return author == null ? Results.BadRequest() : Results.Ok(author);
		}

		private static async Task<IResult> RemoveAuthorAsync(
			[FromRoute] int authorId,
			[FromServices] IAuthorQueryService authorService)
		{
			int? removedAuthorId = await authorService.RemoveAuthorAsync(authorId);

			return removedAuthorId == null ? Results.BadRequest() : Results.Ok(removedAuthorId);
		}
	}
}
