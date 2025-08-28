namespace RaccoonLibrary.Ordering.Domain.Entities
{
	public class Order
	{
		public int OrderId { get; set; }

		public int CustomerId { get; set; }

		public DateOnly OrderDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
	}
}
