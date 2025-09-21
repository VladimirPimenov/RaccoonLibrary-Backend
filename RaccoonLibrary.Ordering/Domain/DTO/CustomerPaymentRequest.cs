namespace RaccoonLibrary.Ordering.Domain.DTO
{
	public record CustomerPaymentRequest
	{
		public int CustomerId { get; init; }

		public string BankCardNumber { get; init; }
	}
}
