using RaccoonLibrary.Ordering.Domain.DTO;

namespace RaccoonLibrary.Ordering.Domain.Contracts
{
	public interface IPaymentApiClient
	{
		public Task<bool> PayOrderAsync(PaymentServiceRequest paymentRequest);
	}
}
