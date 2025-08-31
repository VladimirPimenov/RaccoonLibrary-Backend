using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface ICustomerLibraryService
	{
		public Task AddOrderedBooksToCustomerAsync(Order order);
	}
}
