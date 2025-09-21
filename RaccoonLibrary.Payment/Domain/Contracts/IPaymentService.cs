using RaccoonLibrary.Payment.Domain.DTO;
using RaccoonLibrary.Payment.Domain.Entities;
using RaccoonLibrary.Payment.Domain.Enums;

namespace RaccoonLibrary.Payment.Domain.Contracts
{
	public interface IPaymentService
	{
		public Task<PaymentAccount> RequestOrderPaymentAsync(OrderPaymentRequest paymentRequest);

		public Task<PaymentStatus> RequestPaymentStatusAsync(PaymentAccount payment);

		public Task ClosePaymentAsync(PaymentAccount payment);
	}
}
