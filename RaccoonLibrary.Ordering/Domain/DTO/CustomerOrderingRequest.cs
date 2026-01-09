namespace RaccoonLibrary.Ordering.Domain.DTO
{
	/// <summary>
	/// Представляет запрос клиента на заказ книги.
	/// </summary>
	public record CustomerOrderingRequest
	{
		/// <summary>
		/// Идентификатор клиента.
		/// </summary>
		public int CustomerId { get; init; }

		/// <summary>
		/// Идентификатор книги для заказа.
		/// </summary>
		public int BookId { get; init; }
	}
}
