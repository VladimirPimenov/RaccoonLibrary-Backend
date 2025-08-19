using Microsoft.EntityFrameworkCore;
using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation
{
	public class ReaderBooksRepository(
		PostgreSqlDbContext context)
		: IReaderBooksRepository
	{
		public async Task<List<Book>> GetReaderBooksAsync(int readerId)
		{
			var bookIds = await GetReaderBooksIDsAsync(readerId);

			var books = await context.Book
								.Where(book => bookIds.Contains(book.BookId))
								.ToListAsync();

			return books;
		}

		private async Task<List<int>> GetReaderBooksIDsAsync(int readerId)
		{
			return await context.ReaderBook
								.Where(row => row.ReaderId == readerId)
								.Select(row => row.BookId)
								.ToListAsync();
		}
	}
}
