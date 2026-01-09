using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Ordering.Domain.Contracts;

using RaccoonLibrary.Ordering.Domain.DTO;

namespace RaccoonLibrary.Ordering.Endpoints
{
	/// <summary>
	/// Предоставляет API для управления заказами клиентов.
	/// </summary>
	public static class OrderEndpoints
	{
		/// <summary>
		/// Регистрирует конечные точки API для управления заказами.
		/// </summary>
		public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("orders/{customerId}", GetCustomerOrderAsync);
			app.MapPost("order/book", AddBookToOrderAsync);
			app.MapDelete("order/book", RemoveBookFromOrderAsync);
		}

		/// <summary>
		/// Получает текущий заказ клиента.
		/// </summary>
		/// <param name="customerId">Идентификатор клиента.</param>
		/// <param name="orderService">Сервис для работы с заказами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Возвращает объект заказа.</description></item>
		/// <item><term>404 Not Found</term><description> Заказ для указанного клиента не найден.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> GetCustomerOrderAsync(
			[FromRoute] int customerId,
			[FromServices] IOrderingService orderService)
		{
			var order = await orderService.GetOpenCustomerOrderAsync(customerId);

			return order == null ? Results.NotFound() : Results.Ok(order);
		}

		/// <summary>
		/// Добавляет книгу в текущий заказ клиента.
		/// </summary>
		/// <param name="orderRequest">Запрос, содержащий идентификаторы книги и клиента.</param>
		/// <param name="orderService">Сервис для работы с заказами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Книга успешно добавлена в заказ.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные в запросе или ошибка при добавлении книги.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> AddBookToOrderAsync(
			[FromBody] CustomerOrderingRequest orderRequest,
			[FromServices] IOrderingService orderService)
		{
			var updatedOrder = await orderService.AddBookToCustomerOrderAsync(orderRequest.BookId, orderRequest.CustomerId);

			return updatedOrder == null ? Results.BadRequest() : Results.Ok();
		}

		/// <summary>
		/// Удаляет книгу из текущего заказа клиента.
		/// </summary>
		/// <param name="orderRequest">Запрос, содержащий идентификаторы книги и клиента.</param>
		/// <param name="orderService">Сервис для работы с заказами.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Книга успешно удалена из заказа.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> RemoveBookFromOrderAsync(
			[FromBody] CustomerOrderingRequest orderRequest,
			[FromServices] IOrderingService orderService)
		{
			await orderService.RemoveBookFromCustomerOrderAsync(orderRequest.BookId, orderRequest.CustomerId);

			return Results.Ok();
		}
	}
}
