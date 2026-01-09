namespace RaccoonLibrary.ReaderLibrary.Domain.DTO
{
	/// <summary>
	/// Представляет запрос на добавление книги в библиотеку читателя.
	/// </summary>
	public record BookAddingRequest
	{
		/// <summary>
		/// Идентификатор добавляемой книги.
		/// </summary>
		public int BookId { get; init; }

		/// <summary>
		/// Идентификатор читателя, которому добавляется книга.
		/// </summary>
		public int ReaderId { get; init; }
	}
}
