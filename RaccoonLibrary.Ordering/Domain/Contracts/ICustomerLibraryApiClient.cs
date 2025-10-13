using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface ICustomerLibraryApiClient
	{
		public Task AddOrderedBooksToCustomerAsync(Order order);
	}
}
