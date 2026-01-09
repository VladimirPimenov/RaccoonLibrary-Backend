namespace RaccoonLibrary.Ordering.Domain.Entities
{
	/// <summary>
	/// Представляет клиента, совершающего заказ.
	/// </summary>
	public class Customer
	{
		/// <summary>
		/// Уникальный идентификатор клиента.
		/// </summary>
		public int CustomerId { get; set; }

		/// <summary>
		/// Адрес электронной почты.
		/// </summary>
		public string Email { get; set; }
	}
}
