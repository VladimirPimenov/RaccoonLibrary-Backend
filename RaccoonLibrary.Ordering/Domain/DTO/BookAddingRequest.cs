namespace RaccoonLibrary.Ordering.Domain.DTO
{
	/// <summary>
	/// Представляет запрос на добавление книги клиенту (запрос к Bookshelf API).
	/// </summary>
	public record BookAddingRequest
	{
		/// <summary>
		/// Идентификатор книги.
		/// </summary>
		public int BookId { get; init; }

		/// <summary>
		/// Идентификатор читателя (клиента), которому добавляется книга.
		/// </summary>
		public int ReaderId { get; init; }
	}
}
