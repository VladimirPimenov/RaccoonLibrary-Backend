using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Repositories
{
	public interface IBookRepository
	{
		public Task<Book> GetBookById(int id);
	}
}
