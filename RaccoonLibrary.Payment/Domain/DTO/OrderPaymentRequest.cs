namespace RaccoonLibrary.Payment.Domain.DTO
{
	public class OrderPaymentRequest
	{
		public string BankCardNumber { get; set; }

		public decimal PaymentSum { get; set; }
	}
}
