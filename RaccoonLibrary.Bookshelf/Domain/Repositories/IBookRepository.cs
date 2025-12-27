using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Repositories
{
	public interface IBookRepository
	{
		public Task<Book> GetBookByIdAsync(int id);

		public Task<Book> CreateBookAsync(Book book);

		public Task<Book> UpdateBookAsync(Book book);

		public Task<int> RemoveBookAsync(Book book);

		public Task AddBookAuthorAsync(BookAuthor bookAuthor);

		public Task RemoveBookAuthorAsync(BookAuthor bookAuthor);

		public Task AddBookGenreAsync(BookGenre bookGenre);

		public Task RemoveBookGenreAsync(BookGenre bookGenre);
	}
}
