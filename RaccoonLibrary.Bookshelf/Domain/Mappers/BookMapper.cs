using RaccoonLibrary.Bookshelf.Domain.DTO;
using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.Mappers
{
	public static class BookMapper
	{
		public static BookDto ConvertEntityToDto(Book book)
		{
			return new BookDto
			{
				BookId = book.BookId,
				Title = book.Title,
				Author = $"{book.Author.FirstName[0]}.{book.Author.LastName}",
				Price = book.Price
			};
		}

		public static List<BookDto> ConvertEntitiesToDtoList(List<Book> books)
		{
			var bookDTOs = new List<BookDto>();

			foreach (var book in books)
			{
				bookDTOs.Add(ConvertEntityToDto(book));
			}

			return bookDTOs;
		}
	}
}
