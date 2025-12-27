using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Contracts
{
	public interface IBookQueryService
	{
		public Task<Book> GetBookAsync(int bookId);

		public Task<Book> CreateBookAsync(Book book);

		public Task<int?> RemoveBookAsync(int bookId);

		public Task<Book> AddAuthorToBookAsync(BookAuthor bookAuthor);
				  	
		public Task<Book> RemoveAuthorFromBookAsync(BookAuthor bookAuthor);
		
		public Task<Book> AddGenreToBookAsync(BookGenre bookGenre);
				   	
		public Task<Book> RemoveGenreFromBookAsync(BookGenre bookGenre);
	}
}
