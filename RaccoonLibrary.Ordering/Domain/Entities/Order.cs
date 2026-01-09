using RaccoonLibrary.Ordering.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaccoonLibrary.Ordering.Domain.Entities
{
	/// <summary>
	/// Представляет заказ клиента.
	/// </summary>
	public class Order
	{
		/// <summary>
		/// Уникальный идентификатор заказа.
		/// </summary>
		public int OrderId { get; set; }

		/// <summary>
		/// Идентификатор клиента, создавшего заказ.
		/// </summary>
		public int CustomerId { get; set; }

		/// <summary>
		/// Общая цена заказа.
		/// </summary>
		public decimal OrderPrice { get; set; } = 0.0M;

		/// <summary>
		/// Текущий статус заказа.
		/// </summary>
		public OrderStatus Status { get; set; } = OrderStatus.InProgress;

		/// <summary>
		/// Дата и время оплаты заказа.
		/// </summary>
		public DateTime? PayDate { get; set; } = null;

		/// <summary>
		/// Список заказных книг.
		/// </summary>
		public List<Book> OrderedBooks { get; set; }
	}
}
