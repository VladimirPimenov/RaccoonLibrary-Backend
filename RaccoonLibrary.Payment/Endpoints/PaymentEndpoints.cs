using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RaccoonLibrary.Payment.Domain.Contracts;
using RaccoonLibrary.Payment.Domain.DTO;
using RaccoonLibrary.Payment.Domain.Enums;

namespace RaccoonLibrary.Payment.Endpoints
{
	public static class PaymentEndpoints
	{
		public static void MapPaymentEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapPost("payment", PayOrderAsync);
		}

		private static async Task<IResult> PayOrderAsync(
			[FromBody] OrderPaymentRequest paymentRequest,
			[FromServices] IPaymentService paymentService
			)
		{
			var payment = await paymentService.RequestOrderPaymentAsync(paymentRequest);

			var status = await paymentService.RequestPaymentStatusAsync(payment);

			if (status != PaymentStatus.PaymentSuccessful)
				return Results.BadRequest();

			await paymentService.ClosePaymentAsync(payment);
			return Results.Ok();
		}
	}
}
