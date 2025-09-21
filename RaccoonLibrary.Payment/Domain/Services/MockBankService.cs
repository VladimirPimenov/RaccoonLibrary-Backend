using RaccoonLibrary.Payment.Domain.Contracts;
using RaccoonLibrary.Payment.Domain.DTO;
using RaccoonLibrary.Payment.Domain.Entities;
using RaccoonLibrary.Payment.Domain.Enums;

namespace RaccoonLibrary.Payment.Domain.Services
{
	public class MockBankService : IBankPaymentService
	{
		public async Task<BankPaymentStatus> GetPaymentStatusAsync(int bankPaymentId)
		{
			return BankPaymentStatus.Successful;
		}

		public async Task<int> RequestPaymentAsync(BankPaymentRequest paymentRequest)
		{
			Random rand = new Random();

			return rand.Next(1000000);
		}
	}
}
