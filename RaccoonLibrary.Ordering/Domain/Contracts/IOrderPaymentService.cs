using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	/// <summary>
	/// Интерфейс для обработки платежей по заказам.
	/// </summary>
	public interface IOrderPaymentService
	{
		/// <summary>
		/// Выполняет оплату заказа клиента.
		/// </summary>
		/// <param name="orderRequest">Запрос на оплату заказа.</param>
		/// <returns>Обновленный объект заказа, если оплата прошла успешно, иначе null.</returns>
		public Task<Order> PayOrderAsync(CustomerPaymentRequest orderRequest);
	}
}
