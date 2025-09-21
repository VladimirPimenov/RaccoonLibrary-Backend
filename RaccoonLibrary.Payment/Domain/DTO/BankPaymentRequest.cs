namespace RaccoonLibrary.Payment.Domain.DTO
{
	public record BankPaymentRequest
	{
		public string CardNumber { get; init; }

		public decimal PaymentSum { get; init; }
	}
}
