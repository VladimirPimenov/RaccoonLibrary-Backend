namespace RaccoonLibrary.Bookshelf.Domain.Entities
{
	public class Book
	{
		public int BookId { get; set; }

		public string ISBN { get; set; }

		public string Title { get; set; }

		public string? ShortDescription { get; set; }

		public uint PagesCount { get; set; }

		public decimal Price { get; set; }

		public List<Author> Authors { get; set; }

		public List<Genre> Genres { get; set; }
	}
}