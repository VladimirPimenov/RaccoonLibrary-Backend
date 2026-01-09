namespace RaccoonLibrary.Ordering.Domain.Entities
{
	/// <summary>
	/// Представляет книгу, доступную для заказа.
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

		/// <summary>
		/// Цена книги.
		/// </summary>
		public decimal Price { get; set; }
	}
}
