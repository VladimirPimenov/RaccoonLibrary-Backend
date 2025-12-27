using RaccoonLibrary.Bookshelf.Domain.Entities;

using RaccoonLibrary.Bookshelf.Domain.Repositories;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Domain.Services
{
	public class BookQueryService(
		IBookRepository bookRepository,
		IAuthorRepository authorRepository,
		IGenreRepository genreRepository)
		: IBookQueryService
	{
		public async Task<Book> GetBookAsync(int bookId)
		{
			return await bookRepository.GetBookByIdAsync(bookId);
		}

		public Task<Book> CreateBookAsync(Book book)
		{
			throw new NotImplementedException();
		}

		public async Task<int?> RemoveBookAsync(int bookId)
		{
			Book book = await bookRepository.GetBookByIdAsync(bookId);

			if (book == null)
				return null;

			await bookRepository.RemoveBookAsync(book);

			return bookId;
		}

		public async Task<Book> AddAuthorToBookAsync(BookAuthor bookAuthor)
		{
			Book book = await bookRepository.GetBookByIdAsync(bookAuthor.BookId);
			Author author = await authorRepository.GetAuthorByIdAsync(bookAuthor.AuthorId);

			if (book == null || author == null)
				return null;

			await bookRepository.AddBookAuthorAsync(bookAuthor);

			return book;
		}
		
		public async Task<Book> RemoveAuthorFromBookAsync(BookAuthor bookAuthor)
		{
			Book book = await bookRepository.GetBookByIdAsync(bookAuthor.BookId);
			Author author = await authorRepository.GetAuthorByIdAsync(bookAuthor.AuthorId);

			if (book == null || author == null)
				return null;

			await bookRepository.RemoveBookAuthorAsync(bookAuthor);

			return book;
		}
		
		public async Task<Book> AddGenreToBookAsync(BookGenre bookGenre)
		{
			Book book = await bookRepository.GetBookByIdAsync(bookGenre.BookId);
			Genre genre = await genreRepository.GetGenreByIdAsync(bookGenre.GenreId);

			if (book == null || genre == null)
				return null;

			await bookRepository.AddBookGenreAsync(bookGenre);

			return book;
		}

		public async Task<Book> RemoveGenreFromBookAsync(BookGenre bookGenre)
		{
			Book book = await bookRepository.GetBookByIdAsync(bookGenre.BookId);
			Genre genre = await genreRepository.GetGenreByIdAsync(bookGenre.GenreId);

			if (book == null || genre == null)
				return null;

			await bookRepository.RemoveBookGenreAsync(bookGenre);

			return book;
		}
	}
}
