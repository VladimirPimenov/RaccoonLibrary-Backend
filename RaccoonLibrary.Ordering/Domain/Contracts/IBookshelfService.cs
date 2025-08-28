using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IBookshelfService
	{
		public Task<Book> GetBookByIdAsync(int id);
	}
}
