using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Repositories
{
	public interface BooksRepository
	{
		public Task<List<Book>> GetReaderBooksAsync(int readerId);
	}
}
