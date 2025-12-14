using RaccoonLibrary.Ordering.Domain.Contracts;
using RaccoonLibrary.Ordering.Domain.DTO;

namespace RaccoonLibrary.Ordering.Domain.Services
{
	public class MockBankService: IPaymentApiClient
	{
		public Task<bool> PayOrderAsync(PaymentServiceRequest paymentRequest)
		{
			return Task.FromResult(true);
		}
	}
}
