using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Repositories
{
	public interface IOrderRepository
	{
		public Task<Order> CreateCustomerOrderAsync(Order order, int customerId);

		public Task RemoveOrderAsync(int orderId);

		public Task<Order> GetCustomerOrderAsync(int customerId);

		public Task AddBookToOrderAsync(Book book, Order order);

		public Task RemoveBookFromOrderAsync(int bookId, Order order);
	}
}
