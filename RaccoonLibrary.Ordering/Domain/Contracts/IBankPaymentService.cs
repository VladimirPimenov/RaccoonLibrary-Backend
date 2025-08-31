using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IBankPaymentService
	{
		public Task<int> RequestPaymentAsync(BankPaymentRequest paymentRequest);

		public Task<bool> IsPaymentCompleted(int bankPaymentId);
	}
}
