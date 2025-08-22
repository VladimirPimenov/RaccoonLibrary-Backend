using RaccoonLibrary.Bookshelf.Domain.DTO;
using RaccoonLibrary.Bookshelf.Domain.Entities;

using RaccoonLibrary.Bookshelf.Domain.Repositories;
using RaccoonLibrary.Bookshelf.Domain.Mappers;

using RaccoonLibrary.Bookshelf.Domain.Contracts;

namespace RaccoonLibrary.Bookshelf.Domain.Services
{
	public class BookQueryService(
		IBookRepository bookRepository)
		: IBookQueryService
	{
		public async Task<Book> GetBook(int bookId)
		{
			return await bookRepository.GetBookById(bookId);
		}
	}
}
