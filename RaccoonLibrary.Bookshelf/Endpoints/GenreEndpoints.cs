using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Endpoints
{
	/// <summary>
	/// Предоставляет API для управления жанрами книг.
	/// </summary>
	public static class GenreEndpoints
	{
		/// <summary>
		/// Регистрирует конечные точки API для жанров.
		/// </summary>
		public static void MapGenreEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapPost("/genre", CreateGenreAsync);
			app.MapDelete("/genre/{genreId}", RemoveGenreAsync);
		}

		/// <summary>
		/// Создает новый жанр.
		/// </summary>
		/// <param name="genre">Данные нового жанра.</param>
		/// <param name="genreService">Сервис для работы с жанрами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Возвращает созданный объект жанра.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные жанра.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> CreateGenreAsync(
			[FromBody] Genre genre,
			[FromServices] IGenreQueryService genreService)
		{
			var newGenre = await genreService.CreateGenreAsync(genre);

			return newGenre == null ? Results.BadRequest() : Results.Ok(newGenre);
		}

		/// <summary>
		/// Удаляет жанр по его идентификатору.
		/// </summary>
		/// <param name="genreId">Идентификатор жанра для удаления.</param>
		/// <param name="genreService">Сервис для работы с жанрами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> озвращает идентификатор удаленного жанра.</description></item>
		/// <item><term>400 Bad Request</term><description> Жанр с указанным идентификатором не найден.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> RemoveGenreAsync(
			[FromRoute] int genreId,
			[FromServices] IGenreQueryService genreService)
		{
			int? removedGenreId = await genreService.RemoveGenreAsync(genreId);

			return removedGenreId == null ? Results.BadRequest() : Results.Ok(removedGenreId);
		}
	}
}
