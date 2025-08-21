using RaccoonLibrary.Bookshelf.Domain.DTO;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	public interface IBookQueryService
	{
		public Task<List<BookDto>> GetReaderBooksAsync(int readerId);
	}
}
