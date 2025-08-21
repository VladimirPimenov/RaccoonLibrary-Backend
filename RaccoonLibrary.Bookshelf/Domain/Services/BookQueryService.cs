using RaccoonLibrary.Bookshelf.Domain.DTO;
using RaccoonLibrary.Bookshelf.Domain.Entities;

using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Repositories;
using RaccoonLibrary.Bookshelf.Domain.Mappers;

namespace RaccoonLibrary.Bookshelf.Domain.Services
{
	public class BookQueryService(
		IBookRepository booksRepository)
		: IBookQueryService
	{
		public Task<Book> GetBook(int bookId)
		{
			throw new NotImplementedException();
		}
	}
}
