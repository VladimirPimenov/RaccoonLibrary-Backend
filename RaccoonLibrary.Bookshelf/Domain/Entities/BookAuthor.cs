namespace RaccoonLibrary.Bookshelf.Domain.Entities
{
	/// <summary>
	/// Представляет связь между книгой и ее автором.
	/// </summary>
	public class BookAuthor
	{
		/// <summary>
		/// Уникальный идентификатор связи "Книга-Автор".
		/// </summary>
		public int BookAuthorId { get;set;  }

		/// <summary>
		/// Идентификатор книги.
		/// </summary>
		public int BookId { get; set;  }

		/// <summary>
		/// Идентификатор автора.
		/// </summary>
		public int AuthorId { get; set; }
	}
}

