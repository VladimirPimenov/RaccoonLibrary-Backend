using RaccoonLibrary.Payment.Domain.DTO;
using RaccoonLibrary.Payment.Domain.Enums;

namespace RaccoonLibrary.Payment.Domain.Contracts
{
	public interface IBankPaymentService
	{
		public Task<int> RequestPaymentAsync(BankPaymentRequest paymentRequest);

		public Task<BankPaymentStatus> GetPaymentStatusAsync(int bankPaymentId);
	}
}
