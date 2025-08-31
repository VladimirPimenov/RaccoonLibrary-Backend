using System.ComponentModel.DataAnnotations;

namespace RaccoonLibrary.Ordering.Domain.Entities
{
	public class PaymentAccount
	{
		[Key]
		public int PaymentId { get;set; }

		public int OrderId { get; set; }

		public Order Order { get; set; }

		public int BankPaymentId { get; set; }

		public string BankCardNumber { get;set; }

		public decimal PaymentSum { get;set; }
	}
}
