namespace RaccoonLibrary.Ordering.Domain.DTO
{
	public record CustomerOrderingRequest
	{
		public int CustomerId { get; init; }

		public int BookId { get; init; }
	}
}
