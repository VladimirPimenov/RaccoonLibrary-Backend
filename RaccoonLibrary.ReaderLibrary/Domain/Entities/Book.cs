namespace RaccoonLibrary.ReaderLibrary.Domain.Entities
{
	/// <summary>
	/// Представляет книгу в библиотеке читателя.
	/// </summary>
	public class Book
	{
		/// <summary>
		/// Уникальный идентификатор книги.
		/// </summary>
		public int BookId { get; set; }

		/// <summary>
		/// Название книги.
		/// </summary>
		public string Title { get; set; }
	}
}
