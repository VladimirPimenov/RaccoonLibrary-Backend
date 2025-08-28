using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Repositories
{
	public interface IOrderRepository
	{
		public Task<Order> CreateCustomerOrderAsync(Order order);

		public Task RemoveOrderAsync(int orderId);

		public Task<Order> GetCustomerOrderAsync(int customerId);

		public Task<List<int>> GetOrderBookIdsAsync(int orderId);

		public Task AddBookToOrderAsync(Book book, Order order);

		public Task RemoveBookFromOrderAsync(int bookId, int orderId);
	}
}
