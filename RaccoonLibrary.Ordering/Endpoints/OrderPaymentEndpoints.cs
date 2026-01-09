using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;

namespace RaccoonLibrary.Ordering.Endpoints
{
	/// <summary>
	/// Предоставляет API для обработки платежей по заказам.
	/// </summary>
	public static class PaymentEndpoints
	{
		/// <summary>
		/// Регистрирует конечные точки API для оплаты заказов.
		/// </summary>
		public static void MapPaymentEndpoints(this IEndpointRouteBuilder app)
		{
			app.MapPost("order-payment", PayCustomerOrderAsync);
		}

		/// <summary>
		/// Выполняет запрос на оплату заказа клиента.
		/// </summary>
		/// <param name="paymentRequest">Запрос на оплату заказа.</param>
		/// <param name="paymentService">Сервис для обработки платежей.</param>
		/// <returns>
		/// <list type="table">
		/// <item><term>200 OK</term><description> Заказ успешно оплачен.</description></item>
		/// <item><term>400 Bad Request</term><description> Некорректные данные в запросе или ошибка при оплате заказа.</description></item>
		/// </list>
		/// </returns>
		private static async Task<IResult> PayCustomerOrderAsync(
			[FromBody] CustomerPaymentRequest paymentRequest,
			[FromServices] IOrderPaymentService paymentService
			)
		{
			var paidOrder = await paymentService.PayOrderAsync(paymentRequest);

			return paidOrder == null ? Results.BadRequest() : Results.Ok();
		}
	}
}
