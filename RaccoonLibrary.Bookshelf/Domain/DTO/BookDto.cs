using RaccoonLibrary.Bookshelf.Domain.Entities;

namespace RaccoonLibrary.Bookshelf.Domain.DTO
{
	public record BookDto
	{
		public int BookId { get; init; }

		public string Title { get; init; }

		public string Author { get; init; }

		public decimal Price { get; init; }
	}
}
