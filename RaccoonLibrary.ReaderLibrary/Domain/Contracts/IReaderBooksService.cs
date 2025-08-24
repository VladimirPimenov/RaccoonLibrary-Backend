using RaccoonLibrary.ReaderLibrary.Domain.Entities;

namespace RaccoonLibrary.ReaderLibrary.Domain.Contracts
{
	public interface IReaderBooksService
	{
		public Task<List<Book>> GetReaderBooksAsync(int readerId);
	}
}
