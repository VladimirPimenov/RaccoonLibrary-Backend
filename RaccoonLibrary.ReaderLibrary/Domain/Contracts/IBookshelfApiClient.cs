using RaccoonLibrary.ReaderLibrary.Domain.Entities;

namespace RaccoonLibrary.ReaderLibrary.Domain.Contracts
{
	public interface IBookshelfApiClient
	{
		public Task<Book> GetBookByIdAsync(int id);
	}
}
