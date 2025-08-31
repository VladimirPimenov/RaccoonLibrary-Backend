using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;
using RaccoonLibrary.Ordering.Domain.Entities;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class MockBankService : IBankPaymentService
	{
		public async Task<bool> IsPaymentCompleted(int bankPaymentId)
		{
			return true;
		}

		public async Task<int> RequestPaymentAsync(BankPaymentRequest paymentRequest)
		{
			Random random = new Random();

			return random.Next();
		}
	}
}
