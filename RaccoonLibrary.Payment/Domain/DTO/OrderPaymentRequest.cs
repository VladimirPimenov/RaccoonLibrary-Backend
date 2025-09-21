namespace RaccoonLibrary.Payment.Domain.DTO
{
	public record OrderPaymentRequest
	{
		public string BankCardNumber { get; init; }

		public decimal PaymentSum { get; init; }
	}
}
