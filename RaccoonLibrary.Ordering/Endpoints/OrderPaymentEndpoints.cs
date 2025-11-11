using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;

namespace RaccoonLibrary.Ordering.Endpoints
{
	public static class PaymentEndpoints
	{
		public static void MapPaymentEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapPost("order-payment", PayCustomerOrderAsync);
		}

		private static async Task<IResult> PayCustomerOrderAsync(
			[FromBody] CustomerPaymentRequest paymentRequest,
			[FromServices] IOrderPaymentService paymentService
			)
		{
			var paidOrder = await paymentService.RequestOrderPaymentAsync(paymentRequest);

			if (paidOrder == null)
				return Results.BadRequest();

			return await paymentService.CloseOrderAsync(paidOrder)
							? Results.Ok()
							: Results.BadRequest();
		}
	}
}
