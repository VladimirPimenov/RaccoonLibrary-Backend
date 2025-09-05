using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation
{
	public class BookRepository(
		PostgreSqlDbContext context)
		: IBookRepository
	{
		public async Task<Book> GetBookById(int id)
		{
			return await context.Book
							.Include(book => book.Category)
							.Include(book => book.Author)
							.Include(book => book.Genre)
							.FirstOrDefaultAsync(book => book.BookId == id);
		}
	}
}
