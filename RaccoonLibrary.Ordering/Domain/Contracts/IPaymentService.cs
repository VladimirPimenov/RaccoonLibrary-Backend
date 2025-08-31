using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IPaymentService
	{
		public Task<PaymentAccount> RequestOrderPaymentAsync(CustomerPaymentRequest customerPayRequest);

		public Task<bool> CloseOrderPaymentAsync(PaymentAccount paymentAccount);
	}
}
