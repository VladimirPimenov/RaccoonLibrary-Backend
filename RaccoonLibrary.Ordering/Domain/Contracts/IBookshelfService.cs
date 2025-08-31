using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IBookshelfService
	{
		public Task<Book> GetBookByIdAsync(int id);

		public Task<List<Book>> GetBookListByIdsAsync(List<int> ids);
	}
}
