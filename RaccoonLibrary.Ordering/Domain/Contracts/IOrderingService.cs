using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IOrderingService
	{
		public Task<Order> GetCurrentCustomerOrderAsync(int customerId);

		public Task AddBookToCustomerOrderAsync(int bookId, int customerId);

		public Task RemoveBookFromCustomerOrderAsync(int bookId, int customerId);
	}
}
