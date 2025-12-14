using RaccoonLibrary.Ordering.Domain.Entities;
using RaccoonLibrary.Ordering.Domain.Enums;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IOrderingService
	{
		public Task<Order> GetOpenCustomerOrderAsync(int customerId);

		public Task<int> RemoveOrderAsync(Order order);

		public Task<Order> AddBookToCustomerOrderAsync(int bookId, int customerId);

		public Task RemoveBookFromCustomerOrderAsync(int bookId, int customerId);

		public Task<Order> UpdateOrder(Order order);
	}
}
