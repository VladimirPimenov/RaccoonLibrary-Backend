namespace RaccoonLibrary.Ordering.Domain.DTO
{
	public record PaymentServiceRequest
	{
		public string BankCardNumber { get; init; }

		public decimal PaymentSum { get; init; }
	}
}
