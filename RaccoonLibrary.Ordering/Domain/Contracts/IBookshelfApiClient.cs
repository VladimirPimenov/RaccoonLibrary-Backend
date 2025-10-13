using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IBookshelfApiClient
	{
		public Task<Book> GetBookByIdAsync(int id);

		public Task<List<Book>> GetBookListByIdsAsync(List<int> ids);
	}
}
