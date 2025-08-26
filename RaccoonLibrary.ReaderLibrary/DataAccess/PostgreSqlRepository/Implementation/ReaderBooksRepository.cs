using Microsoft.EntityFrameworkCore;
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
	}
}
