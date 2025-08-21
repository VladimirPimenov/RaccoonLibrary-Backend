using Microsoft.EntityFrameworkCore;
using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation
{
	public class BookRepository(
		PostgreSqlDbContext context)
		: IBookRepository
	{
		public Task<Book> GetBookById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
