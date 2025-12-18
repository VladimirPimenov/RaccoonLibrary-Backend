using RaccoonLibrary.ReaderLibrary.Domain.DTO;
using RaccoonLibrary.ReaderLibrary.Domain.Entities;

namespace RaccoonLibrary.ReaderLibrary.Domain.Contracts
{
	public interface ILibraryService
	{
		public Task<List<Book>> GetReaderBooksAsync(int readerId);

		public Task<ReaderBook> AddBookToReaderAsync(BookAddingRequest request);

		public Task<bool> IsBookInReaderLibraryAsync(int bookId, int readerId);
	}
}
