namespace RaccoonLibrary.Bookshelf.Domain.Entities
{
	/// <summary>
	/// Представляет книгу.
	/// </summary>
	public class Book
	{
		/// <summary>
		/// Уникальный идентификатор книги.
		/// </summary>
		public int BookId { get; set; }

		/// <summary>
		/// Международный стандартный книжный номер (ISBN).
		/// </summary>
		public string ISBN { get; set; }

		/// <summary>
		/// Название книги.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Краткое описание книги.
		/// </summary>
		public string? ShortDescription { get; set; }

		/// <summary>
		/// Количество страниц в книге.
		/// </summary>
		public uint PagesCount { get; set; }

		/// <summary>
		/// Цена книги.
		/// </summary>
		public decimal Price { get; set; }

		/// <summary>
		/// Список авторов книги.
		/// </summary>
		public List<Author> Authors { get; set; }

		/// <summary>
		/// Список жанров книги.
		/// </summary>
		public List<Genre> Genres { get; set; }
	}
}