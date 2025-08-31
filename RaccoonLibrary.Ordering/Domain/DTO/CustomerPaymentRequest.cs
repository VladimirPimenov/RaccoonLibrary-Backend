namespace RaccoonLibrary.Ordering.Domain.DTO
{
	public class CustomerPaymentRequest
	{
		public int CustomerId { get; set; }

		public string BankCardNumber { get;set; }
	}
}
