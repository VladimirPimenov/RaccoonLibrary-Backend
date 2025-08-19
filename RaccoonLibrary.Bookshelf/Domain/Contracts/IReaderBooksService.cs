using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	public interface IReaderBooksService
	{
		public Task<List<Book>> GetReaderBooksAsync(int readerId);
	}
}
