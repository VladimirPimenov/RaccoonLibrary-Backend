namespace RaccoonLibrary.ReaderLibrary.Domain.Entities
{
	/// <summary>
	/// Представляет связь "Читатель-Книга".
	/// </summary>
	public class ReaderBook
	{
		/// <summary>
		/// Уникальный идентификатор записи "Читатель-Книга".
		/// </summary>
		public int ReaderBookId { get;set; }

		/// <summary>
		/// Идентификатор читателя.
		/// </summary>
		public int ReaderId { get; set; }

		/// <summary>
		/// Идентификатор книги.
		/// </summary>
		public int BookId { get; set; }
	}
}
