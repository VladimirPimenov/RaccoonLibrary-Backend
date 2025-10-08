using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IOrderingService
	{
		public Task<Order> GetCustomerOrderAsync(int customerId);

		public Task<int> RemoveOrderAsync(Order order);

		public Task<Order> AddBookToCustomerOrderAsync(int bookId, int customerId);

		public Task RemoveBookFromCustomerOrderAsync(int bookId, int customerId);
	}
}
