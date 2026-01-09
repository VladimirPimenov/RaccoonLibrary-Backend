namespace RaccoonLibrary.Ordering.Domain.Entities
{
	/// <summary>
	/// Представляет связь между заказом и книгой (заказанная книга)..
	/// </summary>
	public class OrderedBook
	{
		/// <summary>
		/// Уникальный идентификатор связи "Заказ-Книга".
		/// </summary>
		public int OrderedBookId { get; set; }

		/// <summary>
		/// Идентификатор заказа.
		/// </summary>
		public int OrderId { get; set; }

		/// <summary>
		/// Идентификатор книги.
		/// </summary>
		public int BookId { get; set; }
	}
}
