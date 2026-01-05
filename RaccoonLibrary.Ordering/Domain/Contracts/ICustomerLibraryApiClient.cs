using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface ICustomerLibraryApiClient
	{
		public Task<bool> AddBookToCustomerAsync(Book book, int customerId);

		public Task<bool> IsBookAlreadyInCustomerLibrary(Book book, int customerId);
	}
}
