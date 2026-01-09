using RaccoonLibrary.Ordering.Domain.Entities;
using RaccoonLibrary.Ordering.Domain.Enums;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	/// <summary>
	/// Интерфейс для управления заказами.
	/// </summary>
	public interface IOrderingService
	{
		/// <summary>
		/// Получает текущий заказ клиента.
		/// </summary>
		/// <param name="customerId">Идентификатор клиента.</param>
		/// <returns>Заказ клиента или null.</returns>
		public Task<Order> GetOpenCustomerOrderAsync(int customerId);

		/// <summary>
		/// Удаляет заказ.
		/// </summary>
		/// <param name="order">Объект заказа для удаления.</param>
		/// <returns>Идентификатор удаленного заказа.</returns>
		public Task<int> RemoveOrderAsync(Order order);

		/// <summary>
		/// Добавляет книгу в заказ клиента.
		/// </summary>
		/// <param name="bookId">Идентификатор книги.</param>
		/// <param name="customerId">Идентификатор клиента.</param>
		/// <returns>Обновленный заказ клиента.</returns>
		public Task<Order> AddBookToCustomerOrderAsync(int bookId, int customerId);

		/// <summary>
		/// Удаляет книгу из заказа клиента.
		/// </summary>
		/// <param name="bookId">Идентификатор книги.</param>
		/// <param name="customerId">Идентификатор клиента.</param>
		/// <returns>Задача, представляющая асинхронную операцию.</returns>
		public Task RemoveBookFromCustomerOrderAsync(int bookId, int customerId);

		/// <summary>
		/// Обновляет информацию о заказе.
		/// </summary>
		/// <param name="order">Объект заказа для обновления.</param>
		/// <returns>Обновленный заказ.</returns>
		public Task<Order> UpdateOrder(Order order);
	}
}
