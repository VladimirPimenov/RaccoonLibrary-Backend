using RaccoonLibrary.Bookshelf.Domain.DTO;
using RaccoonLibrary.Bookshelf.Domain.Entities;

using RaccoonLibrary.Bookshelf.Domain.Contracts;
using RaccoonLibrary.Bookshelf.Domain.Repositories;
using RaccoonLibrary.Bookshelf.Domain.Mappers;


namespace RaccoonLibrary.Bookshelf.Domain.Services
{
	public class BookQueryService(
		BooksRepository booksRepository) 
		: IBookQueryService
	{
		public async Task<List<BookDto>> GetReaderBooksAsync(int readerId)
		{
			var books = await booksRepository.GetReaderBooksAsync(readerId);

			var bookDTOs = BookMapper.ConvertEntitiesToDtoList(books);

			return bookDTOs;
		}
	}
}
