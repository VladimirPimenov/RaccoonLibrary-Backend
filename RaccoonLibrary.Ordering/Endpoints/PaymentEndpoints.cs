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
			app.MapPost("order-payment", PayCustomerOrderAsync)
				.RequireAuthorization();
		}

		private static async Task<IResult> PayCustomerOrderAsync(
			[FromBody] CustomerPaymentRequest paymentRequest,
			[FromServices] IPaymentService paymentService
			)
		{
			var payment = await paymentService.RequestOrderPaymentAsync(paymentRequest);

			if (payment == null)
				return Results.BadRequest();

			return await paymentService.CloseOrderPaymentAsync(payment)
							? Results.Ok()
							: Results.BadRequest();
		}
	}
}
