using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.Domain.Services
{
	public class ReaderBooksService(
		IReaderBooksRepository booksRepository) 
		: IReaderBooksService
	{
		public async Task<List<Book>> GetReaderBooksAsync(int readerId)
		{
			var books = await booksRepository.GetReaderBooksAsync(readerId);

			return books;
		}
	}
}
