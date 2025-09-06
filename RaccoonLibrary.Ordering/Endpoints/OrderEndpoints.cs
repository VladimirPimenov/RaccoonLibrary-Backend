using Microsoft.AspNetCore.Mvc;
using RaccoonLibrary.Ordering.Domain.Contracts;

using RaccoonLibrary.Ordering.Domain.DTO;

namespace RaccoonLibrary.Ordering.Endpoints
{
	public static class OrderEndpoints
	{
		public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("orders/{customerId}", GetCustomerOrderAsync)
				.RequireAuthorization();
			app.MapPost("order/book", AddBookToOrderAsync)
				.RequireAuthorization();
			app.MapDelete("order/book", RemoveBookFromOrderAsync)
				.RequireAuthorization();
		}

		private static async Task<IResult> GetCustomerOrderAsync(
			[FromQuery] int customerId,
			[FromServices] IOrderingService orderService)
		{
			var order = await orderService.GetCustomerOrderAsync(customerId);

			return order == null ? Results.NotFound() : Results.Ok(order);
		}

		private static async Task<IResult> AddBookToOrderAsync(
			[FromBody] CustomerOrderingRequest orderRequest,
			[FromServices] IOrderingService orderService)
		{
			await orderService.AddBookToCustomerOrderAsync(orderRequest.BookId, orderRequest.CustomerId);

			return Results.Ok();
		}

		private static async Task<IResult> RemoveBookFromOrderAsync(
			[FromBody] CustomerOrderingRequest orderRequest,
			[FromServices] IOrderingService orderService)
		{
			await orderService.RemoveBookFromCustomerOrderAsync(orderRequest.BookId, orderRequest.CustomerId);

			return Results.Ok();
		}
	}
}
