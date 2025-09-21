using System.ComponentModel.DataAnnotations;

using RaccoonLibrary.Payment.Domain.Enums;

namespace RaccoonLibrary.Payment.Domain.Entities
{
	public class PaymentAccount
	{
		[Key]
		public int PaymentId { get;set; }

		public int BankPaymentId { get; set; }

		public string BankCardNumber { get;set; }

		public decimal PaymentSum { get;set; }

		public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.PaymentInProgress;
	}
}
