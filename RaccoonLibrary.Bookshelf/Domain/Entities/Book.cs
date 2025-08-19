namespace RaccoonLibrary.Bookshelf.Domain.Entities
{
	public class Book
	{
		public int BookId { get; set; }

		public string ISBN { get; set; }

		public string Title { get; set; }

		public string? ShortDescription { get; set; }

		public int CategoryId { get; set; }
		public Category? Category { get; set; }

		public int GenreId { get; set; }
		public Genre? Genre { get; set; }

		public int AuthorId { get; set; }
		public Author? Author { get; set; }

		public int PublisherId { get; set; }
		public Publisher? Publisher { get; set; }

		public decimal Price { get; set; }
	}
}