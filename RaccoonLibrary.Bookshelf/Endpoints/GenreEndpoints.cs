using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Endpoints
{
	public static class GenreEndpoints
	{
		public static void MapGenreEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapPost("/genre", CreateGenreAsync);
			app.MapDelete("/genre/{genreId}", RemoveGenreAsync);
		}

		private static async Task<IResult> CreateGenreAsync(
			[FromBody] Genre genre,
			[FromServices] IGenreQueryService genreService)
		{
			var newGenre = await genreService.CreateGenreAsync(genre);

			return newGenre == null ? Results.BadRequest() : Results.Ok(newGenre);
		}

		private static async Task<IResult> RemoveGenreAsync(
			[FromRoute] int genreId,
			[FromServices] IGenreQueryService genreService)
		{
			int? removedGenreId = await genreService.RemoveGenreAsync(genreId);

			return removedGenreId == null ? Results.BadRequest() : Results.Ok(removedGenreId);
		}
	}
}
