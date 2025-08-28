using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Repositories
{
	public interface IPaymentRepository
	{
		public Task<PaymentAccount> CreatePaymentAsync(PaymentAccount paymentAccount);

		public Task<int> RemovePaymentAsync(PaymentAccount paymentAccount);
	}
}
