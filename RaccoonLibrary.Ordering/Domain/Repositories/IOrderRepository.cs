using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Repositories
{
	public interface IOrderRepository
	{
		public Task<Order> AddOrderAsync(Order order);

		public Task<int> RemoveOrderAsync(Order order);

		public Task<Order> GetCustomerOrderAsync(int customerId);

		public Task<Order> GetOrderByIdAsync(int orderId);

		public Task<List<int>> GetOrderBookIdsAsync(int orderId);

		public Task AddBookToOrderAsync(int bookId, int orderId);

		public Task RemoveBookFromOrderAsync(int bookId, int orderId);
	}
}
