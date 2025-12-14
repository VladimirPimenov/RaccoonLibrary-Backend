using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface ICustomerLibraryApiClient
	{
		public Task<bool> AddOrderedBooksToCustomerAsync(Order order);
	}
}
