using RaccoonLibrary.ReaderLibrary.Domain.Entities;

namespace RaccoonLibrary.ReaderLibrary.Domain.Repositories
{
	public interface IReaderBooksRepository
	{
		public Task<List<int>> GetBooksIdByReaderIdAsync(int readerId);

		public Task<ReaderBook> AddReaderBookAsync(ReaderBook readerBook);
	}
}
