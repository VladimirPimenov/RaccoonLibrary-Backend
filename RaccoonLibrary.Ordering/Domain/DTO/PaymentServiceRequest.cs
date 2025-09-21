namespace RaccoonLibrary.Ordering.Domain.DTO
{
	public class PaymentServiceRequest
	{
		public string BankCardNumber { get; set; }

		public decimal PaymentSum { get; set; }
	}
}
