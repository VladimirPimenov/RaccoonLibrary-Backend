using RaccoonLibrary.Ordering.Domain.DTO;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	/// <summary>
	/// Определяет методы для взаимодействия с API сервиса оплаты.
	/// </summary>
	public interface IPaymentApiClient
	{
		/// <summary>
		/// Отправляет запрос на оплату заказа.
		/// </summary>
		/// <param name="paymentRequest">Запрос на оплату.</param>
		/// <returns>True, если оплата прошла успешно, иначе False.</returns>
		public Task<bool> PayOrderAsync(PaymentServiceRequest paymentRequest);
	}
}
