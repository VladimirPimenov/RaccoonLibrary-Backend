using RaccoonLibrary.ReaderLibrary.Domain.DTO;
using RaccoonLibrary.ReaderLibrary.Domain.Entities;

using RaccoonLibrary.ReaderLibrary.Domain.Contracts;
using RaccoonLibrary.ReaderLibrary.Domain.Repositories;

namespace RaccoonLibrary.ReaderLibrary.Domain.Services
{
	public class LibraryService(
		IReaderBooksRepository booksRepository,
		IBookshelfApiClient bookshelfService) 
		: ILibraryService
	{
		public async Task<List<Book>> GetReaderBooksAsync(int readerId)
		{
			var bookIds = await booksRepository.GetBooksIdByReaderIdAsync(readerId);

			var bookTasks = bookIds.Select(bookshelfService.GetBookByIdAsync);

			var books = await Task.WhenAll(bookTasks);
			
			return books.ToList();
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

		public async Task<bool> IsBookInReaderLibraryAsync(int bookId, int readerId)
		{
			return await booksRepository.IsBookInReaderLibraryAsync(bookId, readerId);
		}
	}
}
