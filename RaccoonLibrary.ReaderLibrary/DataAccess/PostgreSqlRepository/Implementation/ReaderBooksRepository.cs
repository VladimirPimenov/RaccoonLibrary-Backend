using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.ReaderLibrary.Domain.Entities;
using RaccoonLibrary.ReaderLibrary.Domain.Repositories;

namespace RaccoonLibrary.ReaderLibrary.DataAccess.PostgreSqlRepository.Implementation
{
	public class ReaderBooksRepository(
		PostgreSqlDbContext context) 
		: IReaderBooksRepository
	{
		public async Task<List<int>> GetBooksIdByReaderIdAsync(int readerId)
		{
			return await context.ReaderBook
							.Where(row => row.ReaderId == readerId)
							.Select(row  => row.BookId)
							.ToListAsync(); 
		}

		public async Task<ReaderBook> AddReaderBookAsync(ReaderBook readerBook)
		{
			context.ReaderBook.Add(readerBook);
			await context.SaveChangesAsync();

			return readerBook;
		}

		public async Task<bool> IsBookInReaderLibraryAsync(int bookId, int readerId)
		{
			var book =  await context.ReaderBook.FirstOrDefaultAsync(b =>
								b.BookId == bookId && b.ReaderId == readerId);

			return book == null ? false : true;
		}
	}
}
