using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Endpoints
{
	/// <summary>
	/// Предоставляет API для управления авторами книг.
	/// </summary>
	public static class AuthorEndpoints
	{
		/// <summary>
		/// Регистрирует конечные точки API для авторов.
		/// </summary>
		public static void MapAuthorEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/author/{authorId}", GetAuthorAsync);
			app.MapPost("/author", CreateAuthorAsync);
			app.MapDelete("/author/{authorId}", RemoveAuthorAsync);
		}

		/// <summary>
		/// Получает информацию об авторе по его идентификатору.
		/// </summary>
		/// <param name="authorId">Идентификатор автора.</param>
		/// <param name="authorService">Сервис для работы с авторами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Возвращает объект автора.</description></item>
		/// <item><term>404 Not Found</term><description> Автор с указанным идентификатором не найден.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> GetAuthorAsync(
			[FromRoute] int authorId,
			[FromServices] IAuthorQueryService authorService)
		{
			var author = await authorService.GetAuthorAsync(authorId);

			return author == null ? Results.NotFound() : Results.Ok(author);
		}

		/// <summary>
		/// Создает нового автора.
		/// </summary>
		/// <param name="author">Данные нового автора.</param>
		/// <param name="authorService">Сервис для работы с авторами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Возвращает созданный объект автора.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные автора.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> CreateAuthorAsync(
			[FromBody] Author author,
			[FromServices] IAuthorQueryService authorService)
		{
			var newAuthor = await authorService.CreateAuthorAsync(author);

			return author == null ? Results.BadRequest() : Results.Ok(author);
		}

		/// <summary>
		/// Удаляет автора по его идентификатору.
		/// </summary>
		/// <param name="authorId">Идентификатор автора для удаления.</param>
		/// <param name="authorService">Сервис для работы с авторами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Возвращает идентификатор удаленного автора.</description></item>
		/// <item><term>400 Bad Request</term><description> Автор с указанным идентификатором не найден.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> RemoveAuthorAsync(
			[FromRoute] int authorId,
			[FromServices] IAuthorQueryService authorService)
		{
			int? removedAuthorId = await authorService.RemoveAuthorAsync(authorId);

			return removedAuthorId == null ? Results.BadRequest() : Results.Ok(removedAuthorId);
		}
	}
}
