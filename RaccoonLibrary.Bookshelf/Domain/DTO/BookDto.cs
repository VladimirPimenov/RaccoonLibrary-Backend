using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.DTO
{
	public class BookDto
	{
		public int BookId { get; set; }

		public string Title { get; set; }

		public string Author { get; set; }

		public decimal Price { get; set; }
	}
}
