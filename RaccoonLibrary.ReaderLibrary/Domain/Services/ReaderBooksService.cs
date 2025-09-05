using RaccoonLibrary.ReaderLibrary.Domain.DTO;
using RaccoonLibrary.ReaderLibrary.Domain.Entities;

using RaccoonLibrary.ReaderLibrary.Domain.Contracts;
using RaccoonLibrary.ReaderLibrary.Domain.Repositories;

namespace RaccoonLibrary.ReaderLibrary.Domain.Services
{
	public class ReaderBooksService(
		IReaderBooksRepository booksRepository,
		IBookshelfService bookshelfService) 
		: IReaderBooksService
	{
		public async Task<List<Book>> GetReaderBooksAsync(int readerId)
		{
			var bookIds = await booksRepository.GetBooksIdByReaderIdAsync(readerId);

			var books = new List<Book>();

			foreach (var bookId in bookIds)
			{
				var book = await bookshelfService.GetBookByIdAsync(bookId);

				if(book != null)
					books.Add(book);
			}
			
			return books;
		}

		public async Task<ReaderBook> AddBookToReaderAsync(BookAddingRequest request)
		{
			var addingBook = new ReaderBook
			{
				BookId = request.BookId,
				ReaderId = request.ReaderId
			};

			var addedBook = await booksRepository.AddReaderBookAsync(addingBook);

			return addedBook;
		}
	}
}
