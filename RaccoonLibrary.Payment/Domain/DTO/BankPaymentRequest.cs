namespace RaccoonLibrary.Payment.Domain.DTO
{
	public class BankPaymentRequest
	{
		public string CardNumber { get; set; }

		public decimal PaymentSum { get; set; }
	}
}
