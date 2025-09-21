using RaccoonLibrary.Payment.Domain.Entities;

namespace RaccoonLibrary.Payment.Domain.Repositories
{
	public interface IPaymentRepository
	{
		public Task<PaymentAccount> CreatePaymentAsync(PaymentAccount paymentAccount);

		public Task<PaymentAccount> UpdatePaymentAsync(PaymentAccount paymentAccount);

		public Task<int> RemovePaymentAsync(PaymentAccount paymentAccount);
	}
}
