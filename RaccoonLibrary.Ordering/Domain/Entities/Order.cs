using RaccoonLibrary.Ordering.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaccoonLibrary.Ordering.Domain.Entities
{
	public class Order
	{
		public int OrderId { get; set; }

		public int CustomerId { get; set; }

		public decimal OrderPrice { get; set; } = 0.0M;

		public OrderStatus Status { get; set; } = OrderStatus.InProgress;

		public DateTime? PayDate { get; set; } = null;

		[NotMapped]
		public List<Book> OrderedBooks { get; set; }
	}
}
