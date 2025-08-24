using RaccoonLibrary.ReaderLibrary.Domain.Entities;

namespace RaccoonLibrary.ReaderLibrary.Domain.Contracts
{
	public interface IBookshelfService
	{
		public Task<Book> GetBookByIdAsync(int id);
	}
}
