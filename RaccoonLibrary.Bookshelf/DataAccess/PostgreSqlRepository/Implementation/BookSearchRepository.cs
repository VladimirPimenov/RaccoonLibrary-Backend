using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation
{
	public class BookSearchRepository(
		PostgreSqlDbContext context)
		: IBookSearchRepository
	{
		public async Task<List<Book>> FindBooksByAuthorAsync(string authorLastName)
		{
			return await context.Book
							.Include(book => book.Category)
							.Include(book => book.Genre)
							.Include(book => book.Author)
							.Include(book => book.Publisher)
							.Where(book =>
								EF.Functions.Like(
									book.Author.LastName.ToLower(),
									authorLastName)
								)
							.ToListAsync();
		}

		public async Task<List<Book>> FindBooksByGenreAsync(string genreName)
		{
			return await context.Book
							.Include(book => book.Category)
							.Include(book => book.Genre)
							.Include(book => book.Author)
							.Include(book => book.Publisher)
							.Where(book =>
								EF.Functions.Like(
									book.Genre.Name.ToLower(),
									genreName)
								)
							.ToListAsync();
		}

		public async Task<List<Book>> FindBooksByPublisherAsync(string publisherName)
		{
			return await context.Book
							.Include(book => book.Category)
							.Include(book => book.Genre)
							.Include(book => book.Author)
							.Include(book => book.Publisher)
							.Where(book =>
								EF.Functions.Like(
									book.Publisher.Name.ToLower(),
									publisherName)
								)
							.ToListAsync();
		}

		public async Task<List<Book>> FindBooksByTitleAsync(string title)
		{
			return await context.Book
							.Include(book => book.Category)
							.Include(book => book.Genre)
							.Include(book => book.Author)
							.Include(book => book.Publisher)
							.Where(book => 
								EF.Functions.Like(
									book.Title.ToLower(),
									title)
								)
							.ToListAsync();
		}
	}
}
