using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	public interface IBookQueryService
	{
		public Task<Book> GetBook(int bookId);
	}
}
