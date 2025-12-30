using Microsoft.EntityFrameworkCore;

using RaccoonLibrary.Bookshelf.Domain.Entities;
using RaccoonLibrary.Bookshelf.Domain.Repositories;

namespace RaccoonLibrary.Bookshelf.DataAccess.PostgreSqlRepository.Implementation
{
	public class BookRepository(
		PostgreSqlDbContext context)
		: IBookRepository
	{
		public async Task<Book> GetBookByIdAsync(int id)
		{
			Book book = await context.Book
								.Include(b => b.Authors)
								.Include(b => b.Genres)
								.FirstOrDefaultAsync(b => b.BookId == id);
			return book;
		}

		public async Task<Book> CreateBookAsync(Book book)
		{
			foreach(Author author in book.Authors)
			{
				context.Entry(author).State = EntityState.Unchanged;
			}

			foreach (Genre genre in book.Genres)
			{
				context.Entry(genre).State = EntityState.Unchanged;
			}

			context.Book.Add(book);
			await context.SaveChangesAsync();

			return book;
		}

		public async Task<int> RemoveBookAsync(Book book)
		{
			context.Remove(book);

			await context.SaveChangesAsync();

			return book.BookId;
		}

		public async Task<Book> UpdateBookAsync(Book book)
		{
			context.Attach(book);

			await context.SaveChangesAsync();

			return book;
		}

		public async Task AddBookAuthorAsync(BookAuthor bookAuthor)
		{
			context.BookAuthor.Add(bookAuthor);

			await context.SaveChangesAsync();
		}

		public async Task RemoveBookAuthorAsync(BookAuthor bookAuthor)
		{
			var entity = await context.BookAuthor
								.Where(b => 
									b.AuthorId == bookAuthor.AuthorId 
									&& b.BookId == bookAuthor.BookId)
								.FirstOrDefaultAsync();

			context.BookAuthor.Remove(entity);

			await context.SaveChangesAsync();
		}

		public async Task AddBookGenreAsync(BookGenre bookGenre)
		{
			context.BookGenre.Add(bookGenre);

			await context.SaveChangesAsync();
		}

		public async Task RemoveBookGenreAsync(BookGenre bookGenre)
		{
			var entity = await context.BookGenre
								.Where(b =>
									b.GenreId == bookGenre.GenreId
									&& b.BookId == bookGenre.BookId)
								.FirstOrDefaultAsync();

			context.BookGenre.Remove(entity);

			await context.SaveChangesAsync();
		}
	}
}
