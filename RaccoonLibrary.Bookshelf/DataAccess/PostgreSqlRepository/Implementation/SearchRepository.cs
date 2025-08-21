using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation
{
	public class SearchRepository(
		PostgreSqlDbContext context)
		: ISearchRepository
	{
		public async Task<List<Author>> FindAuthorByLastName(string lastName)
		{
			return await context.Author
							.Where(author =>
								EF.Functions.Like(
									author.LastName.ToLower(),
									lastName)
							)
							.ToListAsync();
		}

		public async Task<List<Book>> FindBooksByAuthorAsync(string authorLastName)
		{
			return await context.Book
							.Include(book => book.Category)
							.Include(book => book.Genre)
							.Include(book => book.Author)
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
							.Where(book =>
								EF.Functions.Like(
									book.Genre.Name.ToLower(),
									genreName)
								)
							.ToListAsync();
		}

		public async Task<List<Book>> FindBooksByTitleAsync(string title)
		{
			return await context.Book
							.Include(book => book.Category)
							.Include(book => book.Genre)
							.Include(book => book.Author)
							.Where(book => 
								EF.Functions.Like(
									book.Title.ToLower(),
									title)
								)
							.ToListAsync();
		}
	}
}
