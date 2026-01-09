namespace RaccoonLibrary.Bookshelf.Domain.Entities
{
	/// <summary>
	/// Представляет связь между книгой и ее жанром.
	/// </summary>
	public class BookGenre
	{
		/// <summary>
		/// Уникальный идентификатор связи "Книга-Жанр".
		/// </summary>
		public int BookGenreId { get;set;  }

		/// <summary>
		/// Идентификатор книги.
		/// </summary>
		public int BookId { get; set;  }
		
		/// <summary>
		/// Идентификатор жанра.
		/// </summary>
		public int GenreId { get; set; }
	}
}

